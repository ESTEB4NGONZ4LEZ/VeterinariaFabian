## VETERINARIA  

- Se ha creado una semilla para testear los endpoints.
- JWT y Refresh Token funcional. ( El endpoint Get de medicamento utiliza autorizacion y se puede verificar por roles)
- Todos los endpoints de paginacion usan la version 1.1 el resto usa la version 1.0 por defecto

### Consultas

1. Crear un consulta que permita visualizar los veterinarios cuya especialidad sea Cirujano vascular.

```
http://localhost:5287/api/Veterinario/cirujanoVascular
```
2. Listar los medicamentos que pertenezcan a el laboratorio Genfar

```
http://localhost:5287/api/Medicamento/laboratorioGenfar
```

3. Mostrar las mascotas que se encuentren registradas cuya especie sea felina.

```
http://localhost:5287/api/Mascota/felino
```

4. Listar los propietarios y sus mascotas.

```
http://localhost:5287/api/Propietario/propietarioxMascota
```

5. Listar los medicamentos que tenga un precio de venta mayor a 50000

```
http://localhost:5287/api/Medicamento/medicamento>50000
```

6. Listar las mascotas que fueron atendidas por motivo de vacunacion en el primer trimestre del 2023

```
http://localhost:5287/api/Mascota/vacunacion
```


