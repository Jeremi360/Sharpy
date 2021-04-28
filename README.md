# For now there is only Minsk Complicator basing on this youtube series:
<https://www.youtube.com/watch?v=wgHIkdUQbp0&list=PLRAdsfhKI4OWNOSfS7EUu5GRAVmze1t2y&index=1>

# Myhton
My own programing langue.
Inspired by Python, CSharp, CoffeeScript, GDScript and MVC.

## Mython Concepts

- divide your code to rule it
- every thing is public
- every thing is overrideable
- use **MC** and **MVC** patters
- use of **TOML** for models serialization
- expandable enums at runtime
- `static` like `static` in **C#** 
- simple `switch` like **GDScript**'s `match`
- getset like in **C#**

## Hello Myhton

```coffee
package HelloMythonApp

controller HelloMython:

  def static main(list<str> args):
    print("Hello Myhton!")

```

### Use MVC 

So there will be 2 special types modules that made any class in Myton:
*But you can also made old school class, using `controller`, if you need to.*
- `model`
- `controller`
They are designed to be used in **MC** (*model-controller*) or **MVC** (*model-viewier-controller*) patters.
There is no *viewer* or *class* module, because they have different applications, but the same functionality as `controller`.

- `model` - there is only data there that means vars and constants

```coffee
# SomeModel.my
package SomeApp

model SomeModel:
  const x = 3
  some_var = "x"
  str some_string = "a"
  bool boolean_var = true #or false 
  int some_int = 2
  float some_float = 0.3
  list<int> some_int_list: 1 3 4
  list some_mixed_list: "a" 2 false
  dict<str, str> some_dict:
    "key1": "value"
    "key2": "other_value"
  # dict can be mixed in the similar way as list

  # like in python there is no real private
  _some_prev_var = "this is private!"

  enum SomeEnum: One, Two, Three

``` 

- *viewer/editor/render/etc* - (this one is optional)
  there is only some staff for render, ui or editor in game engines
  some vars, properties (*getset*), add special ui/render/editor functions

```coffee
# SomeViewer.my
package SomeApp
from SomeUIFramework import *

controller SomeViewer(Window):
  use SomeModel
  # viewer (controller) can use few different models if needed
  use AnotherModel

  attr SomeUIAttribute
  some_ui_useful_var = "text"

  def init(string title = "Myhton Window App"):
    enum.Add("Four")
    base.init(title)

  on ui_update
  def do_some_ui_stuff():
    pass
  
```

- `controller` - one that is mostly similar to old school class
  mostly logic, some vars and properties (*getset*)

```coffee
# SomeController.my
package SomeApp

controller SomeController:
  use SomeModel

  # if need controller can use different models if needed
  use YetAnotherModel

  some_var => _some_prev_var

  on game_input
  def move_the_player list inputs:
    pass()

```

- to combine them or to be old school class just use `controller`

```coffee
package SomeApp

controller SomeClass:
  use SomeViewer
  use SomeController
  # you can split your logic to few different controllers if needed
  use SomeOtherController

```

- this also means easier dealing with types, beacuse you can do this:

```coffee
model<SomeModel> some_var;
controller<SomeController> some_var;
```

## Switch

```coffee
switch x:
  1:
    print("It's one!")
  2:
    print("It's one times two!")
  default:
    print("It's not 1 or 2. I don't care to be honest.")
```

## Set Get

```coffee
some_readonly_var => some_other_var

get some_var:
  return some_another_var

set some_var:
  some_another_var = value

```
