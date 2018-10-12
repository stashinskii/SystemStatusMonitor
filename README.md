# System Status Monitor Widget: simple Metro UI application for managing your PC

Basic features includes:

* Simple information about CPU
* Disk space
* OS information
* etc.


Solution designed using IoC-container (Ninject) for dependency resolving. Project consists of:

| Module | Link |
| ------ | ------ |
| BLL Implementation| Provides all services for managing application |  
| BLL Prototype | Provides all interfaces used in BLL |
| IoC-container config (Ninject) | Dependency Resolving configuratiom module |
| WPF UI | Presentation layer for your application (Metro UI) |
| Tests | Service's unit tests (NUnit) |

|Next iteration, soon:||
| ------ | ------ |
| DAL Prototype | Provides all interfaces used in DAL |
| DAL (Entity Framework) | EF implementation for DAL |