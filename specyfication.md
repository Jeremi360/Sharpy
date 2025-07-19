# Sharpy (code name)

This langue is inspired by C#, nim, Python, GDScript and natural langue.

I want to avoid brackets as much as possible in this langue.

It uses `:;` instead of brackets and for code blocks.

I use a lot of indent, but its optional, 
but should give waring about making bad code ;)

## Comments

```
# one-line comment

## multi-lines
	comment ##
```

## Variable declaration

```
# var types are strong
# new null var of given type
# by default vars are public
var var_name: VarType

# new private var int
priv var _private_var = 0

# new public-static var int
static var static_var = 0

# new var of given type
var var_name = VarType: args for constructor;

## example
var var_name = Vector2: 100, 100;

## or - colons are optional,
## when using args_names we can put args in any order
var var_name = Vector2: y=100 x=100;

# example of basic types vars
## Strings
### one-line string
var text = "some text"

### multi-line string
### parser should ignore tabs at start
### of line like in pythons """muli-line strings"""
var text =: "first line
			second line
			third line" ;

# Booleans
var var_name = condition

## conditions can have few lines

var var_name =: condition1
				or condition2
				and not condition3;

## true
var var_name = true

## false
var var_name = false

# Int
var some_int = 0
 
# Float
# I hate .0 and 0. - don't do this
var some_float = 0.0

# We can use set-get like in C#/GDScript
var getter: Type:
	get: # code return something;
;

var limited_var: Type:
	set value: # code that do something with value; 
	get: # code return something;
;

## example
var HP: Int:
	set value: HP = clamp: value 0 100;;
	get: return HP;;
```

## Constants

The same way as variables, but using `const` key word instead of `var`
`const const_name = Vector2: 100, 100;`

## Enums

```
# by default Enums are public
# We define new enums like this
enum EnumName:
	EnumOp1
	EnumOp2
;

# We can change enum options values
enum EnumName:
	EnumOp1
	EnumOp2 = 7
;

# We can change type options values
enum EnumName: String:
	EnumOp1 = "1"
	EnumOp2 = "7"
;

```

## Functions

```
# by default functions are public
# empty func
func func_name:; 

# func without args
func func_name:
	# body_function
;

# func with args - colons are optional
func func_name: arg1:Type, arg1:Type; -> ReturnedType:
	# body_function
	return some_new_var
;

# func with args with default vars - colons are optional
func func_name: arg1=true, arg1:Type; -> ReturnedType:
	# body_function
	return some_new_var
;

# func can be public-static or private like vars
static func func_name:;

priv func _func_name:;
```

## Code blocks

### Ifs

```
# Simple Ifs
if one-line condition:
	# code
;

if multi-line condition;:
	# code
;

if condition:
	# code
;else:
	# else code
;

# Use `if` like an `switch-case`
if some_var == value_a: # first case
		# code
	;
	== value_b: # second case is like `if some_var == value_b`
		# code
	; > value_c: # third case is like `if some_var > value_c`
		# code
	;!= value_d:
		# code
	;else: # default case
		# else code
;; # we ends else-code-block and switch-block at once

# for conditions we can use python keywords:
# not, and, or, in, true and false
```

## Loops

```
# For loop
for x in list:
	# code
	# we can use keywords: "break", "continue" and "return"
	# we can use keyword "skip" instead of "continue" 
;

# we also have loops: while, while-do
# but also have loops: until - is shortcut for `while not condition`:  
until x=3:
	# code
;
```

## Classes

```
# by default classes are public
class ClassName: # by default class inherits from Object
	# code
;

class ClassName: InheritedType;:
	# code
;

# we can use Interfaces like in C#
class ClassName: InheritedType, InterfaceType1, InterfaceType2;: # colons are optional
	# code
;

# we can import to classes from different script like in Python
import gi, os, importlib
gi.require_version:'Gtk', '4.0';
from gi.repository import 

# Calling funcs or set/get vars from other objects
class ClassName:
	var some_obj = obj: arg1, arg2;

	# also we do Constructors like in C#
	func ClassName(arg1, arg2, arg3):
		some_obj.call_some_0args_func:;
		some_obj.call_some_func: arg2, arg1;
		some_obj.some_var = arg3
	;
;
```

## Collections

```
# List
var some_list = List:Type: element01 element02;;

## example
var some_ints = List:int: 1 4;;

## but type is optional as we can predict it form first element of list
var some_ints = List: 1 4;

# Dictionary
var some_dict = Dict:Type1 Type2: key01=a_value key02=b_value;;

## example
var some_dict = Dict:String Int: "key01"=0 "key02"=7;;

## but type is optional as we can predict it form first key-value pair of dict
var some_dict = Dict: "key01"=0 "key02"=7;

```

## Signal/Events

```
# define signals like in GDScript
signal sig_name
signal some_signal: arg1:Type arg2:Type;

## then to connect func signal we do
on some_signal
func _on_some_signal: arg1:Type arg2:Type;:
	# code
;

## or in code-block
on button.pressed: _on_some_signal;
```

## Some other quirks
```
# we can like C do:
some_int++
some_int--
```