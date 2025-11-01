from regex import *
from parser import *


test_code = """
class SomeClass
extends Object
# test comment
var some_var = 3
const some_const: int = 5
error
"""
compile_regexes()
analize_code(test_code)