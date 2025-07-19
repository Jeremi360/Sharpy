import unittest
from src.lexer.lexer import lexer

class TestLexer(unittest.TestCase):

		def test_tokens(self):
			data = """
			var x = 10;
			priv var y = 20;
			static var z = x + y;
			func my_function:
				if x > y: z = x - y;
				;else: z = y - x;
			;
			"""

			lexer.input(data)
			tokens = []

			while True:
				tok = lexer.token()
				if not tok: break
				tokens.append((tok.type, tok.value))

			expected_tokens = [
				('VAR', 'var'), ('IDENTIFIER', 'x'), ('EQUALS', '='), ('NUMBER', 10), ('SEMICOLON', ';'),
				('PRIV', 'priv'), ('VAR', 'var'), ('IDENTIFIER', 'y'), ('EQUALS', '='), ('NUMBER', 20), ('SEMICOLON', ';'),
				('STATIC', 'static'), ('VAR', 'var'), ('IDENTIFIER', 'z'), ('EQUALS', '='), ('IDENTIFIER', 'x'), ('PLUS', '+'), ('IDENTIFIER', 'y'), ('SEMICOLON', ';'),
				('FUNC', 'func'), ('IDENTIFIER', 'my_function'), ('COLON', ':'),
				('IF', 'if'), ('IDENTIFIER', 'x'), ('GREATER', '>'), ('IDENTIFIER', 'y'), ('COLON', ':'),
				('IDENTIFIER', 'z'), ('EQUALS', '='), ('IDENTIFIER', 'x'), ('MINUS', '-'), ('IDENTIFIER', 'y'), ('SEMICOLON', ';'),
				('ELSE', 'else'), ('COLON', ':'),
				('IDENTIFIER', 'z'), ('EQUALS', '='), ('IDENTIFIER', 'y'), ('MINUS', '-'), ('IDENTIFIER', 'x'), ('SEMICOLON', ';'),
				('SEMICOLON', ';')
			]

			self.assertEqual(tokens, expected_tokens)

if __name__ == "__main__":
	unittest.main()
