# Collections.Fluent - Fluent Collection Extensions for .NET

## Introduction

*Collections.Fluent* is a small portable class library that tries to move the focus away from collection types back to the elements stored in them. It does that by introducing a number of [extension methods](https://msdn.microsoft.com/en-us//library/bb383977.aspx) that flip the order of the method parameters.

Instead of ``collection.Add(element)``, you may use ``element.AddTo(collection)``, or instead of ``collection.Remove(element)``, ``element.RemoveFrom(collection)`` can be used, you get the idea.

By itself, that does not seem like an improvement, but when you use a [fluent API](https://en.wikipedia.org/wiki/Fluent_interface) and [method chaining](https://en.wikipedia.org/wiki/Method_chaining) to parameterize objects, the last step is often to add an element to a collection. For example:

	var container = new StackPanel();
	
	new Label()
		.Text("Hello")
		.YAlign(VerticalAlignment.Top)
		.XAlign(HorizontalAlignment.Center)
		.AddTo(container.Children);

If the `AddTo` method would not be supported, you'd need to break the flow of the method chain and add an additional statement:

	container.Children.Add(label);

Well, you may think now that there are not so many fluent APIs available for .NET, and you are right. Specifically user interfaces are mostly set up by XAML and in code by assigning properties. And that's why I am trying to create a [fluent API generator for C#](https://github.com/pragmatrix/AutoFluent). 

## Extension Methods

*Collection.Fluent* implements the following extension methods:

### Adding elements to a collection

- `element.AddTo(collection)` adds the element to a collection and returns it.
- `element.RemoveFrom(collection)` removes the element from a collection and returns the element.
- `element.IsIn(collection)` tests if the element is contained in the collection and returns a *bool*.

### If the collection is a dictionary, i.e. supports a key / value pair

- `element.AddTo(key, dictionary)` adds the element with the key to the dictionary.
- `element.SetIn(key, dictionary)` sets a key / element in the dictionary and returns the element.
- `key.RemoveKeyFrom(dictionary)` removes the key from the dictionary and returns the key.
- `key.IsKeyIn(dictionary)` tests if a key is in the dictionary and returns a *bool*.

### Additional overloads for dictionaries

- `element.AddTo(Func<element, key>, dictionary)` adds the element with the key that is returned by the key generator to the collection and returns the element.
- `element.RemoveFrom(Func<element, key>, dictionary)` removes the element with the key that is returned by the key generator from the dictionary and returns the element.
- `element.IsIn(Func<element, key>, dictionary)` tests if the key that is returned by the key generator is in the dictionary and returns a *bool*.

### For indexable collections, like a List, or an Array

- `element.InsertIn(index, list)` inserts the element at the index in the list and returns the element.
- `element.IndexIn(list)` returns the index of the element inside the list, or `-1` if it the element is not in the list.
- `element.SetInAt(index, list)` sets the element at the index in the list and returns the element.
- `element.RemoveFromAt(index, list)` removes the element at the index from the list and returns the element.

### Queues

- `element.EnqueueIn(queue)` enqueues the element in the queue and returns the element.

### Stacks

- `element.PushIn(stack)` pushes the element on the stack and returns it.

## Conventions

The names of the extension methods adhere to the following rules:

- When a *bool* is returned, the method is prefixed by `Is`.
- When an index is returned, the method begins with `Index`.
- When an index is used to modify a collection, the method ends with an `At`.
- In general, when an extension method modifies a collection, it contains an `In` to indicate the reversed order of arguments and to avoid collisions with existing methods. However, there are two exceptions: in case an element is removed, the `In` is replaced by `From`, and when an element is added, the `In` gets replaced by `To`.

## License & Copyright

License: BSD

Copyright © 2015 Armin Sander










