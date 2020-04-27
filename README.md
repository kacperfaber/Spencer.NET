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

### Usage
* [Installing package](#installing-package)
* [Adding using statement](#adding-using)
* [Creating new Container](#create-container)
* [Creating new ReadOnlyContainer](#create-readonlycontainer)
* [Creating Storage](#create-storage)

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

