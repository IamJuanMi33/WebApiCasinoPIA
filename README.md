# WebApiCasinoPIA
Esta es una API RESTful desarrollada en C# para la gestión de rifas y participantes. La API permite realizar operaciones CRUD (Crear, Leer, Actualizar, Borrar) tanto para rifas como para los participantes asociados. El proyecto sigue una arquitectura basada en controladores y utiliza entidades y DTOs (Data Transfer Objects) para manejar los datos. También está integrada con una base de datos para almacenar la información de forma persistente.

## Funcionalidades principales
* Operaciones CRUD: Se soportan operaciones de creación, lectura, actualización y eliminación de rifas y participantes.
* Conexión a base de datos: La API se conecta a una base de datos para almacenar y gestionar los registros de rifas y participantes.

### Operaciones CRUD Rifas
El programa cuenta con un controlador base para las operaciones de las rifas, donde se encuentran los _endpoints_ para obtener una lista de todas las rifas creadas, obtener una rifa en específico por medio de un id, crear una rifa, modificar una rifa en particular por medio de un id y eliminar una rifa.

### Operaciones CRUD Participantes
El programa cuenta con un controlador base para las operaciones de los participantes, donde se encuentran los _endpoints_ para obtener todos los participantes creados, agregar un participante, modificar un participante en particular por medio de un id y eliminar un participante.

### Entidades y DTOs
El programa cuenta con entidades específicas para rifas y para participantes, con atributos únicos para identificar cada una. De igual forma se cuenta con una entidad para la relación MaM (Muchos a Muchos). Además, también se cuentan con DTOs (Data Transfer Objects) para manejar de manera más segura dichas entidadades, así como la Base de Datos. 


## 
Esta API de Gestión de Rifas es perfecta para el manejo de un Casino, pues proporciona una plataforma robusta para crear y administrar rifas de forma eficiente, así como sus participantes. Ideal tanto para pequeñas aplicaciones como para sistemas empresariales, esta API te permite gestionar todo el ciclo de vida de una rifa, desde la creación hasta la administración detallada de los participantes.
