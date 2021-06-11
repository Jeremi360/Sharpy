parser grammar MythonPasser
	;

options {
	tokenVocab = MythonLexer;
}

program
	: package_ topLevelDecl* EOF
	;

package_
  : 'package' IDENTIFIER NEWLINE
  ;

	// | import
	// | modelDecl
	// | controller

topLevelDecl
	: 
  | classVarDecl
	| constDecl
	| signalDecl
	| enumDecl
	| methodDecl
	// | usage
	;

classVarDecl
	: typed_identifier (
		'=' expression
	) NEWLINE
	;

set
	: 'set' IDENTIFIER ':' stmtOrSuite
	;

get
  : 'get' IDENTIFIER ':' stmtOrSuite
  ;

typeHint
	: BUILTINTYPE
	| IDENTIFIER
	;

typed_identifier
  : ('var'|typeHint) IDENTIFIER
  ;

constDecl
	: 'const' (typeHint)? IDENTIFIER  '=' expression NEWLINE
	;

signalDecl
	: 'signal' IDENTIFIER signalParList? NEWLINE
	;
signalParList
	: '(' (IDENTIFIER (COMMA IDENTIFIER)*)? ')'
	;

enumDecl
	: 'enum' IDENTIFIER ('{'|':') (
		IDENTIFIER ('=' expression)? (
			COMMA IDENTIFIER ( '=' expression)?
		)* COMMA?
	) '}'? NEWLINE
	;

onSignal
 : 'on' IDENTIFIER NEWLINE
 ;

methodDecl
	: onSignal? 'def' 'static'? typed_identifier '(' parList? ')'':' stmtOrSuite
	;
parList
	: parameter (COMMA parameter)?
	;
parameter
	: typed_identifier ('=' expression)?
	;

argList
	: expression (COMMA expression)*
	;

stmtOrSuite
	: stmt
	| NEWLINE INDENT suite DEDENT
	;
suite
	: stmt+
	;

stmt
	: varDeclStmt
	| ifStmt
	| forStmt
	| whileStmt
	| switchStmt
	| flowStmt
	| assignmentStmt
	| exprStmt
	// | waitStmt
	// | 'breakpoint' stmtEnd
	| 'pass' stmtEnd
	;
stmtEnd
	: NEWLINE
	;

ifStmt
	: 'if' expression ':' stmtOrSuite (
		'elif' expression ':' stmtOrSuite
	)* ('else' ':' stmtOrSuite)?
	;
whileStmt
	: 'while' expression ':' stmtOrSuite
	;
forStmt
	: 'for' IDENTIFIER 'in' expression ':' stmtOrSuite
	;

switchStmt
	: 'switch' expression NEWLINE INDENT switchBlock DEDENT
	;
switchBlock
	: (patternList ':' stmtOrSuite)+
	;
patternList
	: pattern (COMMA pattern)*
	;
// Note: you can't have a binding in a pattern list, but to not complicate the grammar more it won't
// be restricted syntactically
pattern
	: literal
	| BUILTINTYPE
	| CONSTANT
	| DEFAULT
	| arrayPattern
	| dictPattern
	;

arrayPattern
	: '[' (pattern (COMMA pattern)* '..'?)? ']'
	;
dictPattern
	: '{' keyValuePattern? (COMMA keyValuePattern)* '..'? '}'
	;
keyValuePattern
	: STRING (':' pattern)?
	;

flowStmt
	: 'skip' stmtEnd
	| 'break' stmtEnd
	| RETURN expression? stmtEnd
	;

assignmentStmt
	: expression (
		'='
		| '+='
		| '-='
		| '*='
		| '/='
		| '%='
		| '&='
		| '|='
		| '^='
	) expression stmtEnd
	;
varDeclStmt
	: typed_identifier ('=' expression)? stmtEnd
	;


// waitStmt
// 	: 'wait' '(' (expression COMMA expression) ')'
// 	;

mathCondition
  : '<'
  | '>'
  | '<='
  | '>='
  | '=='
  | '!='
  ;


exprStmt
	: expression stmtEnd
	;
expression
	: expression '[' expression ']' # subscription
	| expression 'as' typeHint # cast
	| expression 'if' expression 'else' expression # ternacyExpr
	| expression ('or') expression # logicOr
	| expression ('and') expression # logicAnd
	| ('!' | 'not') expression # logicNot
	| expression 'in' expression # in
	| expression (mathCondition) expression # comparison
	| expression '|' expression	 # bitOr
	| expression '^' expression	 # bitXor
	| expression '&' expression	 # bitAnd
	| expression ('<<' | '>>') expression	 # bitShift
	| expression '-' expression	 # minus
	| expression '+' expression # plus
	| expression ('*' | '/' | '%') expression # factor
	| ('-' | '+') expression # sign
	| '~' expression # bitNot
	| expression 'is' (IDENTIFIER | BUILTINTYPE) # is
	| expression '(' argList? ')' # call
	| '.' IDENTIFIER '(' argList? ')' # call
	| expression '.' IDENTIFIER # attribute
	| 'true' # primary
	| 'false' # primary
	| 'null' # primary
	| 'self' # primary
	| literal # primary
	| '[' (expression ( COMMA expression)*)? ']' # arrayDecl
	| '{' (keyValue (COMMA keyValue)*)? '}' # dictDecl
	| '(' expression ')' # primary
	;

literal
	: STRING
	| INTEGER
	| FLOAT
	| IDENTIFIER
	| BUILTINTYPE
	| CONSTANT
	;

keyValue
	: expression ':' expression
	| IDENTIFIER '=' expression
	;