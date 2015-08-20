# Collections.Fluent - Fluent Collection Extensions for .NET

## Introduction

*Collections.Fluent* is a small portable class library that tries to move the focus away from collection types back to the elements stored in them. It does that by introducing a number of [extension methods](https://msdn.microsoft.com/en-us//library/bb383977.aspx) that flip the order of the method parameters.

Instead of ``collection.Add(element)``, you may use ``element.AddTo(collection)``, or instead of ``collection.Remove(element)``, ``element.RemoveFrom(collection)`` can be used, you get the idea.

By itself, that does not seem like an improvement, but when you use a [fluent API](https://en.wikipedia.org/wiki/Fluent_interface) and [method chaining](https://en.wikipedia.org/wiki/Method_chaining) that parameterizes objects, the last step is often to add an element to a collection. For example:

	var container = new StackPanel();
	
	new Label()
		.Text("Hello")
		.YAlign(VerticalAlignment.Top)
		.XAlign(HorizontalAlignment.Center)
		.AddTo(container.Children)

If the `AddTo` method would not be supported, you'd need to break the flow of the method chain and add an additional statement:

	container.Children.Add(label);

Well, you may think now that there are not so many fluent APIs available on .NET, and you are right. Specifically user interfaces are mostly set up by XAML and in code by assigning properties. And that's why I am trying to create an automatic fluent API generator, called [AutoFluent](https://github.com/pragmatrix/AutoFluent). 

## Conventions








