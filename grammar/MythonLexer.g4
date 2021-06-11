
lexer grammar MythonLexer;

tokens {
	INDENT,
	DEDENT
}

options {
	superClass = MythonLexerBase;
}


SET: 'set';
GET: 'get';
VALUE: 'value';

CONST: 'const';

SIGNAL: 'signal';
ON: 'on';

ENUM: 'enum';

ATTR: 'attr';
STATIC: 'static';
VAR: 'var';
DEF: 'def';

PACKAGE : 'package';
FROM : 'from';
IMPORT: 'import';
CONTROLLER : 'controller';
MODEL: 'model';
USE: 'use';
BASE: 'base';

// BREAKPOINT: 'breakpoint';
PASS: 'pass';

IF: 'if';
ELIF: 'elif';
WHILE: 'while';
FOR: 'for';
IN: 'in';

SWITCH: 'switch';
DEFAULT: 'default';

// Instead of confusing `continue`
SKIP_FOR: 'skip';

BREAK: 'break';

SUGAR_RETURN: '=>';
RETURN: 'return'|SUGAR_RETURN;

// Instead of `yield`
// I don't know if it is needed
WAIT: 'wait';

AS: 'as';
ELSE: 'else';
OR: 'or';
AND: 'and';
NOT: 'not';
IS: 'is';
TRUE: 'true';
FALSE: 'false';
NULL: 'null';
SELF: 'self';


NEWLINE
	: (
		{atStartOfInput()}? SPACE
		| ( '\r'? '\n' | '\r' | '\f') SPACE?
	) {onNewLine();}
	;

IDENTIFIER
	: [_a-zA-Z][_0-9a-zA-Z]*
	;
BUILTINTYPE
	: 'bool'
	| 'int'
	| 'float'
	| 'str'
	| MODEL
	| CONTROLLER
	| ENUM
	| 'dict'
	| 'list'
	;
CONSTANT // TODO: really?
	: 'PI'
	| 'TAU'
	| 'INF'
	| 'NAN'
	;

STRING
	: '"' STRING_CONTENT* '"'
	| '\'' STRING_CONTENT* '\''
	;
fragment STRING_CONTENT
	: ~[\\\r\n'"]
	| '\\' [abfnrtv'"\\]
	| '\\u' HEX HEX HEX HEX
	;
INTEGER
	: '0' [xX] HEX+
	| DEC+
	| '0' [bB] [01]+
	;
fragment DEC
	: [0-9]
	;
fragment HEX
	: [0-9a-fA-F]
	;
FLOAT
	: DEC? '.' DEC ([eE] [+-] DEC)?
	| DEC [eE] [+-] DEC
	;
DOT: '.';
DOTDOT: '..';
COMMA: ','|' ';
COLON: ':';
ASSIGN: '=';
COLON_ASSIGN: ':=';
ADD_ASSIGN: '+=';
MINUS_ASSIGN: '-=';
MUL_ASSIGN: '*=';
DIV_ASSIGN: '/=';
MOD_ASSIGN: '%=';
AND_ASSIGN: '&=';
OR_ASSIGN: '|=';
XOR_ASSIGN: '^=';
OPEN_PAREN: '(' {openBrace();};
CLOSE_PAREN: ')' {closeBrace();};
OPEN_BRACE: '{' {openBrace();};
CLOSE_BRACE: '}' {closeBrace();};
OPEN_BRACK: '[' {openBrace();};
CLOSE_BRACK: ']' {closeBrace();};
OPEN_ARROW: LESS_THAN {openBrace();};
CLOSE_ARROW: GREATER_THAN {closeBrace();};
LOGIC_NOT: '!';
LESS_THAN: '<';
GREATER_THAN: '>';
EQUALS: '==';
GT_EQ: '>=';
LT_EQ: '<=';
NOT_EQ: '!=';
OR_OP: '|';
XOR: '^';
AND_OP: '&';
LEFT_SHIFT: '<<';
RIGHT_SHIFT: '>>';
ADD: '+';
MINUS: '-';
STAR: '*';
DIV: '/';
MOD: '%';
NOT_OP: '~';
SKIP_
	: (SPACE | COMMENT | LINE_JOINING) -> skip
	;
fragment SPACE
	: [ \t]+
	;
fragment COMMENT
	: '#' ~[\r\n]*
	;
fragment LINE_JOINING
	: '\\' SPACE? ('\r\n' | [\r\n])
	;