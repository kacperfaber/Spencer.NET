# Spencer.NET

Open Source project of smart **IoC Container** made by programmer for programmer.
<br>
<br>
<br>

### Author
Kacper Faber, Poland

<br>

### Requires 
* **NET STANDARD 2.0** <br>or newest<br>

* **.NET CORE 2.0** <br>or newest<br>

* **.NET FRAMEWORK 4.61**<br> or newest

<br>

### Usage
* [Installing package](#installing-package)
* [Adding using statement](#adding-using)
* [Creating new Container](#create-container)
* [Creating new ReadOnlyContainer](#create-readonlycontainer)
* [Creating Storage](#create-storage)
* [Using parametrized constructors](#parametrized-constructors)
* [Factories](#factories)
* [Inject, TryInject, Auto](#injections)

<br>

#### Installing package
Spencer.NET is avaible on nuget.org.
<br>
You can use one of follow commands.
> dotnet add package Spencer.NET

> Install-Package Spencer.NET

<br>


#### Adding using 
Spencer.NET using one statement for every feature. 
<br>
It is it.
> using Spencer.NET;

<br>

#### Create Container
Constructors of both of containers are too long to 
<br> 
writing use it by contributor programmer.
<br>
You can use tested and safely **ContainerFactory** class
>`IContainer container = ContainerFactory.Container();`

<br>


#### Create ReadOnlyContainer
Constructors of both of containers are too long to 
<br> 
writing use it by contributor programmer.
<br>
You can use tested and safely **ContainerFactory** class
<br>
> **This container cannot be updated in him lifetime**
<br>
> **You should provide instance of Storage class**
<br>
> **Prefered way is using StorageBuilder**
<br>

>`IReadOnlyContainer container = ContainerFactory.ReadOnlyContainer(storage);`

<br>

#### Create Storage 
ReadOnlyContainer cannot be updated in him lifetime.
<br>
To provides static registrations, you have to use instance of  `Storage` class
<br>
Prefered way is using `StorageBuilder` class.
<br>
>`StorageBuilder.Build():IStorage` 
><br>
>Returns Storage instance
><br>

>`StorageBuilder.Register<T>():StorageBuilder` 
><br>
>Registering class or interface

>`StorageBuilder.Register(Type):StorageBuilder`
><br>
>Registering class or interface

>`StorageBuilder.Register(params object[]):StorageBuilder`
><br>
>Registering class or interface using constructor
><br>
>with compatible parameters

>`StorageBuilder.Register(Type, params object[]):StorageBuilder`
><br>
>Registering class or interface using constructor
><br>
>with compatible parameters

>`StorageBuilder.RegisterObject(object):StorageBuilder`
><br>
>Registering class with instance gived in parameter.
><br>
>Registration type will be taken from unboxed instance.
>

>`StorageBuilder.RegisterObject<T>(T):StorageBuilder`
><br>
>Registering class with instance of gived in parameter.
><br>
>Registration type will be taken from **T**.

>`StorageBuilder.RegisterAssembly(Assembly):StorageBuilder`
><br>
> Registering assembly types.

>`StorageBuilder.RegisterAssembly(AssemblyName):StorageBuilder`
><br>
> Registering assembly types

>`StorageBuilder.RegisterAssemblies(params Assembly[]):StorageBuilder`
><br>
> Registering assembly types

>`StorageBuilder.RegisterAssemblies(params AssemblyName[]):StorageBuilder`
><br>
> Registering assembly types

<br>

#### Parametrized Constructors

Mechanism for finding constructor always will be picking accessible and 
<br>
with the smallest count of parameters he have, or he could have.
<br>
You would use `ServiceConstructor` attribute?
<br>
If you want dynamically choose constructor you would to use, 
<br>
i'm providing functionality to find constructor by given parameters.
<br>
Lets see the sample... :>

``` 
class Test
{
    // #1
    public Test(int x) {}
    
    // #2
    public Test(int x, int y) {}

    // #3 
    public Test(string str, bool b) {}
}

// Container.Register<Test>(0);
// Will invoke #1 constructor
// params
// x = 0

// Container.Register<Test>(1, 2);
// Will use #2 constructor
// params
// x = 1,
// y = 2

// Container.Register<Test>(true, "Hello World!");
// Will use #3 constructor
// params 
// str = "Hello World!"
// b = true
```

<br>

#### Factories
Factories is a static methods generating instance of a class.
<br>
> They can returns interface, if they will have a `FactoryResult(Type)` attribute,
<br>
> which will be pointing to the valid returns type.

> They can take dependencies as their parameters

```
class Test 
{
    Test() {}
        
    [Factory]
    public static Test FactoryMethod() => new Test();
}
```

```
interface ITest 
{
}

class Test : ITest
{
    Test() {}
        
    [Factory]
    [FactoryResult(typeof(Test))
    public static ITest FactoryMethod() => new Test();
}
```

<br>

#### Injections
Spencer.NET want to help you. If you want, you cannot inject everything in constructor.
<br>
I am providing attributes `Inject`, `TryInject` and `Auto`.

> Inject way is not recommended for good **Dependency Injection**
<br>

- Injections
    * `Inject` trying to resolve instance from self Container, 
    <br>
    if could not found any matching will throw `ResolveException`
    
    * `TryInject` trying to resolve instance from self Container,
    <br>
    if could not found any matching set variable to `null`
    
- `Auto` initializing simple types 
    
```
class OldWay
{
    public IEnumerable<int> Ints { get; set; }
    public IDep Dep { get; set; }
    
    public OldWay(IDep dep)
    {
        Dep = dep;
        Ints = new List<int>();
    }
}

class NewWay
{
    [Auto]
    public IEnumerable<int> Ints { get; set; }

    [Inject]
    public IDep Dep { get; set; } 
}
```
