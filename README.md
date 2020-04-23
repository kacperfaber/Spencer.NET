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

* [Add using statement](#adding-using-statement)

<br>
<br>
<br>

#### Installing package ####
Spencer.NET is avaible on nuget.org.
<br>
You can use one of follow commands.
> dotnet add package Spencer.NET

> Install-Package Spencer.NET

<br>

#### Adding using statement ####
Spencer.NET using one statement for every feature. 
<br>
It is it.
> using Spencer.NET;

<br>

#### Create new Container
Constructors of both of containers are too long to 
<br> 
writing use it by contributor programmer.
<br>
You can use tested and safely **ContainerFactory** class
>IContainer container = ContainerFactory.Container();

<br>



#### Create new ReadOnlyContainer
Constructors of both of containers are too long to 
<br> 
writing use it by contributor programmer.
<br>
You can use tested and safely **ContainerFactory** class
<br>
<br>
**This container cannot be updated in him lifetime**
<br>
**You should provide instance of Storage class**
<br>
**Prefered way is using StorageBuilder**
<br>
>IReadOnlyContainer container = ContainerFactory.ReadOnlyContainer(storage);
<br>





