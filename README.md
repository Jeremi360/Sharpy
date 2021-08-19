
# MCScript
My own programing langue.
Inspired by Python, CSharp, CoffeeScript, GDScript and MVC.

## Mython Concepts

- divide your code to rule it
- every thing is public
- every thing is overrideable
- use **MC** and **MVC** patters
- use of **TOML** for models serialization
- expandable enums at runtime
- `static` like in **C#** 
- simple `switch` like **GDScript**'s `match`
- getset like in **C#**
- only easy to understand sugar code, **non** lambdas
- `skip` instead of confusing `continue` in `for` loop
- `wait` instead of confusing `yield`
- commas (`,`) are optional
- blocks of code starts with `:` and ends with `end`
- keywords `use`, `as` and `hide` can be used
  to differentiate between values and functions with
  that same name, but form different modules/controllers
- one file = one module/controller

## Hello MCScript

```coffee
package HelloMythonApp

def controller HelloMython

def static main(list<str> args):
  print("Hello MCScript!")
end

```

### Use MVC 

So there will be 2 special types modules that made any class in MCScript:
*But you can also made old school class, using `controller`, if you need to.*
- `model`
- `controller`
They are designed to be used in **MC** (*model-controller*) or **MVC** (*model-viewier-controller*) patters.
There is no *viewer* or *class* module, because they have different applications, but the same functionality as `controller`.

- `model` - there is only data there that means vars and constants

```coffee
# SomeModel.my
package SomeApp

def model SomeModel

const x = 3
var some_var = "x"
str some_string = "a"
bool boolean_var = true #or false 
int some_int = 2
float some_float = 0.3
list<int> some_int_list: 1 3 4 end
list some_mixed_list: "a" 2 false end
dict<str, str> some_dict:
  "key1": "value"
  "key2": "other_value"
end
# dict can be mixed in the similar way as list

# like in python there is no real private
var _some_prev_var = "this is private!"

enum SomeEnum: One Two Three

``` 

- *viewer/editor/render/etc* - (this one is optional)
  there is only some staff for render, ui or editor in game engines
  some vars, properties (*getset*), add special ui/render/editor functions

```coffee
# SomeViewer.my
package SomeApp
from SomeUIFramework import *

def controller SomeViewer
use Window
use SomeModel
# viewer (controller) can use few different models if needed
use AnotherModel

attr SomeUIAttribute
var some_ui_useful_var = "text"

def init(str title = "MCScript Window App"):
  SomeEnum.Add("Four")
  base.init(title)
end

on ui_update
def do_some_ui_stuff():
end
```

- `controller` - one that is mostly similar to old school class
  mostly logic, some vars and properties (*getset*)

```coffee
# SomeController.my
package SomeApp

def controller SomeController

use SomeModel

# if need controller can use different models if needed
use YetAnotherModel

var some_var => _some_prev_var

on game_input
def move_the_player(list inputs):
end

```

- to combine them or to be old school class just use `controller`

```coffee
package SomeApp

def controller SomeClass

use SomeViewer
use SomeController
# you can split your logic to few different controllers if needed
use SomeOtherController

```

## Switch

```coffee
switch x:
  1:
    print("It's one!")
  end

  2:
    print("It's one times two!")
  end

  default:
    print("It's not 1 or 2. I don't care to be honest.")
  end
end
```

## Set Get

```coffee
var some_readonly_var => some_other_var

get some_var:
  return some_another_var
end

set some_var:
  some_another_var = value
end

```

## What if controller/model has different vars/functions with that same name?

```coffee
package SomeApp

def controller AnotherTextController

# so for example this 2 models has var with the same name `text`
use SomeTextModel
use AltTextModel

# so we can hide one of them
hide AltTextModel.text

# or we can change it name
use AltTextModel.text as alt_text

# we can do the same with functions

use TextController
use AltTextController

# we can hide one of them
hide TextController.draw

# or we can change it name
use TextController.draw as _draw
```