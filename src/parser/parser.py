import ply.yacc as yacc
from src.lexer.lexer import tokens

# Precedence rules for the parser
precedence = (
	('left', 'PLUS', 'MINUS'),
	('left', 'MULTIPLY', 'DIVIDE'),
	('left', 'GREATER', 'LESS', 'GREATER_EQUAL', 'LESS_EQUAL', 'NOT_EQUAL'),
	('right', 'EQUALS'),
)

# Dictionary to hold variable names
names = {}

# Program structure
def p_program(p):
	'program : statement_list'
	print("DEBUG: Token stream:", p.slice)
	p[0] = ('program', p[1])

def p_statement_list(p):
	'''statement_list : statement_list statement
	| statement'''
	if len(p) == 3: p[0] = p[1] + [p[2]]
	else: p[0] = [p[1]]

# Statements
def p_statement_var_declaration(p):
	'statement : VAR IDENTIFIER EQUALS expression SEMICOLON'
	names[p[2]] = p[4]
	p[0] = ('var_declaration', p[2], p[4])

def p_statement_assignment_or_expression(p):
	'''statement : IDENTIFIER EQUALS expression SEMICOLON
								| expression SEMICOLON'''
	if len(p) == 5: p[0] = ('assignment', p[1], p[3])
	else: p[0] = ('expression', p[1])

# Add rules for if-else statements
def p_statement_if(p):
		'statement : IF expression COLON statement_list SEMICOLON'
		print("DEBUG: if rule triggered with:", p[2], p[4])
		p[0] = ('if', p[2], p[4])

def p_statement_if_else(p):
	'statement : IF expression COLON statement_list SEMICOLON ELSE COLON statement_list SEMICOLON'
	print("DEBUG: if_else rule triggered with:", p[2], p[4], p[7])
	p[0] = ('if_else', p[2], p[4], p[7])

# Expressions
def p_expression_binop(p):
	'''expression : expression PLUS expression
								| expression MINUS expression
								| expression MULTIPLY expression
								| expression DIVIDE expression
								| expression GREATER expression
								| expression LESS expression
								| expression GREATER_EQUAL expression
								| expression LESS_EQUAL expression
								| expression NOT_EQUAL expression'''
	p[0] = ('binop', p[2], p[1], p[3])

def p_expression_group(p):
	'expression : LPAREN expression RPAREN'
	p[0] = p[2]

def p_expression_number(p):
	'expression : NUMBER'
	p[0] = ('number', p[1])

def p_expression_identifier(p):
	'expression : IDENTIFIER'
	p[0] = ('identifier', p[1])

def p_error(p):
	if p: raise SyntaxError(f"Syntax error at '{p.value}' on line {p.lineno}")
	else: raise SyntaxError("Syntax error at EOF")

# Build the parser
parser = yacc.yacc()
