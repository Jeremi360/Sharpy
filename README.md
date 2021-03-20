# For now there is only Minsk Complicator basing on this youtube series:
<https://www.youtube.com/watch?v=wgHIkdUQbp0&list=PLRAdsfhKI4OWNOSfS7EUu5GRAVmze1t2y&index=1>

# Myhton
My own programing langue.
Inspired by Python, CSharp, CoffeeScript, Markdown and MVC.

## Mython Concepts

### Use MVC 

So there will be 3 special types modules that made any class in Myton. 
*But you can also made old school class too if you need to.*

- `model` - there is only data there that means vars and constants;

```python
# SomeModel.my
model SomeModel:
  conts x = 3
  some_var = "a"
  bool boolean_var = true #or false 
  int some_int = 2
  float some_float = "s"
  list some_list: 1 3 4
  dict some_dict:
    "key1": "value"
    "key2": "other_value"
  # like in python there is no real private
  _some_prev_var = "this is private!"

  enum SomeEnum: One, Two, Three

``` 

- `viewer` - there is only some staff for render, ui or editor in game engines
  some vars, properties (*getset*), add special ui/render/editor funcs


```python
# SomeViewer.my
viewer SomeViewer:
  use SomeModel
  # viewer can use few different models if needed
  use AnotherModel

  attr SomeUIAttribute
  some_ui_useful_var = "text"

  on ui_update
  def do_some_ui_stuff():
    pass
  
```

- `controller` - one that is mostly similar to old school class
  mostly logic, properties (*getset*)

```python
# SomeController.my
controller SomeController:
  use SomeModel

  # if need controller can use different models if needed
  use YetAnotherModel

  some_var => _some_prev_var

  on game_input
  def move_the_player list inputs:
    pass()

```

- `class` to combine them or to be old school class

```python
class SomeClass:
  use SomeViewer
  use SomeController
  # you can split your logic to few different controllers if needed
  use SomeOtherController

```

