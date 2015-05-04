# Dependency-Injection-Example
An example of multiple dependency injection designs. Done in C#.

This is a simple program that has working examples of three different dependency injection methods:
* constructor injection
* method injection
* property injection.

Main will ask the user for an input and send that input into a class called MessageCenter. MessageCenter has a method, Post() that will call the write() method from one of the color writers (RedWriter, BlueWriter, or GreenWriter).

MessageCenter has a 'pen' attribute which is an abstraction of the Writer interface that the color writers implement.

By injecting the dependency of the lower lever color writers into the higher level MessageCenter, the program becomes more modular. 

The most practical benefit of this is for unit testing. By exercising smart dependency control we can test units of programs individually without relying on creating (and therefore testing) other units that would be required to run it.
