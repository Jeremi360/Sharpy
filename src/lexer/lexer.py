import ply.lex as lex

# List of token names
tokens = (
	'IDENTIFIER', 'NUMBER', 'STRING', 'COLON', 'SEMICOLON',
	'EQUALS', 'PLUS', 'MINUS', 'MULTIPLY', 'DIVIDE',
	'LPAREN', 'RPAREN', 'NEWLINE', 'COMMENT',
	'GREATER', 'LESS', 'GREATER_EQUAL', 'LESS_EQUAL', 'NOT_EQUAL',
	'PLUS_EQUAL', 'MINUS_EQUAL', 'MULTIPLY_EQUAL', 'DIVIDE_EQUAL'
)

# Reserved keywords
reserved = {
	'var': 'VAR',
	'priv': 'PRIV',
	'static': 'STATIC',
	'const': 'CONST',
	'func': 'FUNC',
	'if': 'IF',
	'else': 'ELSE',
	'for': 'FOR',
	'while': 'WHILE',
	'until': 'UNTIL',
	'enum': 'ENUM',
	'class': 'CLASS',
	'signal': 'SIGNAL',
	'on': 'ON',
	'true': 'TRUE',
	'false': 'FALSE'
}

tokens = tokens + tuple(reserved.values())

# Regular expression rules for simple tokens
t_ignore = ' \t'  # Ignore spaces and tabs
t_COLON = r':'
t_SEMICOLON = r';'
t_EQUALS = r'='
t_PLUS = r'\+'
t_MINUS = r'-'
t_MULTIPLY = r'\*'
t_DIVIDE = r'/'
t_LPAREN = r'\('
t_RPAREN = r'\)'
t_GREATER = r'>'
t_LESS = r'<'
t_GREATER_EQUAL = r'>='
t_LESS_EQUAL = r'<='
t_NOT_EQUAL = r'!='
t_PLUS_EQUAL = r'\+='
t_MINUS_EQUAL = r'-='
t_MULTIPLY_EQUAL = r'\*='
t_DIVIDE_EQUAL = r'/='

def t_IDENTIFIER(t):
	r'[a-zA-Z_][a-zA-Z0-9_]*'
	t.type = reserved.get(t.value, 'IDENTIFIER')  # Check for reserved words
	return t

def t_NUMBER(t):
	r'\d+(\.\d+)?'
	t.value = float(t.value) if '.' in t.value else int(t.value)
	return t

def t_STRING(t):
	r'"([^\\\n]|(\\.))*?"'
	t.value = t.value[1:-1]  # Remove quotes
	return t

def t_COMMENT(t):
	r'\#.*'
	pass  # Ignore comments

def t_NEWLINE(t):
	r'\n+'
	t.lexer.lineno += len(t.value)
	pass

def t_error(t):
	print(f"Illegal character '{t.value[0]}' at line {t.lineno}")
	t.lexer.skip(1)

# Build the lexer
lexer = lex.lex()
