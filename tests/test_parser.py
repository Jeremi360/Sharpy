import unittest
from src.parser.parser import parser

class TestParser(unittest.TestCase):

	def test_var_declaration(self):
		data = "var x = 10;"
		result = parser.parse(data)
		expected = ('program', [('var_declaration', 'x', ('number', 10))])
		self.assertEqual(result, expected)

	def test_expression(self):
		data = "x = (5 + 3) * 2;"
		result = parser.parse(data)
		expected = ('program', [('assignment', 'x', ('binop', '*', ('binop', '+', ('number', 5), ('number', 3)), ('number', 2)))])
		self.assertEqual(result, expected)

	def test_syntax_error(self):
		data = "var x = ;"
		with self.assertRaises(SyntaxError): parser.parse(data)

	def test_if_statement(self):
		data = "if x > 5: x = 10; ;"
		result = parser.parse(data)
		expected = ('program', [(
			'if', ('binop', '>', ('identifier', 'x'), ('number', 5)),
				[('assignment', 'x', ('number', 10))]
			)])
		self.assertEqual(result, expected)

	## to fix
	def test_if_else_statement(self):
		data = "if x > 5: x = 10; ;else: x = 20; ;"
		result = parser.parse(data)
		expected = ('program', [(
			'if_else', ('binop', '>', ('identifier', 'x'), ('number', 5)),
				[('assignment', 'x', ('number', 10))], 
				[('assignment', 'x', ('number', 20))]
			)])
		self.assertEqual(result, expected)

if __name__ == "__main__":
	unittest.main()
