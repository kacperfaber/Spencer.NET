# Spencer.NET

Open Source project of smart **IoC Container** made by programmer for programmer.
<br>
<br>
<br>

### Requires 
* **NET STANDARD 2.0** <br>or newest
<br>

* **.NET CORE 2.0** <br>or newest<br>

* **.NET FRAMEWORK 4.61**<br> or newest

<br>

### Containers
- `ReadOnlyContainer : IReadOnlyContainer`
    * `ReadOnlyContainer.Resolve<T>():T`
    <br>
   Returns T instance or throws exception.
    * `ReadOnlyContainer.Resolve(Type):object`
    <br>
    Returns instance or throws exception.
    * `ReadOnlyContainer.ResolveOrDefault(Type):object`
    <br>
    Returns instance or null
    * `ReadOnlyContainer.ResolveOrDefault<T>():T`
    <br>
    Returns instance or null.
    * `ReadOnlyContainer.ResolveMany(Type):IEnumerable<object>`
    <br>
    Returns all types of types assignable to parameter type
    * `ReadOnlyContainer.ResolveMany<T>():IEnumerable<T>`
    <br>
    Returns all instances of types assignable to parameter type
    * `ReadOnlyContainer.Has<T>():bool`
    <br>
    Checking is assignable type exist
    
    * `ReadOnlyContainer.Has(Type):bool`
    <br>
    Checking is assignable type exist
    
    <br>
    

- `Container : ReadOnlyContainer, IContainer`
    * `Container.ResolveOrAuto<T>():T`
    <br>
    Returns existing instance or registering new and returns her.
    * `Container.ResolveOrAuto(Type):object`
    <br>
    Returns existing instance or register new and returns her.
    * `Container.Register<T>():void`
    <br> 
    Registering class or implementantions of interface
    * `Container.Register(Type):void`
    <br>
    Register class or implementantions of interface
    * `Container.RegisterObject(object):void`
    <br>
    Registering class with instance
    <br>
    He will taken registration type of unboxed instance.
    * `Container.RegisterObject<T>(T):void`
    <br>
    Registering class with instance.
    He will taken registration type of generic **T**
    
    * `Container.Register<T>(params object[]):void`
    <br>
    Registering class using constructor will compatible parameters
    

### Usage
* [Installing package](#installing-package)
* [Adding using statement](#adding-using)
* [Creating new Container](#create-container)
* [Creating new ReadOnlyContainer](#create-readonlycontainer)
* [Creating Storage](#create-storage)

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
>**This container cannot be updated in him lifetime**
<br>
>**You should provide instance of Storage class**
<br>
>**Prefered way is using StorageBuilder**
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
i providing functionality to find constructor by given parameters.
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
