## TODO
- Improve logging managment
- Improve Sample, desacoplando del los modulos identity por default
- Add HTML to PDF gen with dinktopdf
- Todo, integrate billing settings
- imrpoove widget for move
- improve catalog for integrate
- agregar componente text area...
- hay un modulo de catalogo, convertir a modulo
## About this solution

This is a minimalist, non-layered startup solution with the ABP Framework. All the fundamental ABP modules are already installed.

## How to run

The application needs to connect to a database. Run the following command in the `Acme.Samples` directory:

````bash
dotnet run --migrate-database
````

This will create and seed the initial database. Then you can run the application with any IDE that supports .NET.

Happy coding..!



# notes



-a---           3/24/2023  3:11 PM           4507 01.json
-a---           3/24/2023  3:11 PM          48514 02.json
-a---           3/24/2023  3:11 PM           4056 03.json
-a---           3/24/2023  3:11 PM          23067 04.json
-a---           3/24/2023  3:11 PM           1356 05.json
-a---           3/24/2023  3:30 PM            813 06.json
-a---           3/24/2023  3:30 PM           2198 07.json
-a---           3/24/2023  3:30 PM            416 08.json
-a---           3/24/2023  3:30 PM           1123 09.json
-a---           3/24/2023  3:30 PM            385 10.json
-a---           3/24/2023  3:30 PM            303 11.json
-a---           3/24/2023  3:30 PM            918 12.json
-a---           3/24/2023  3:30 PM            997 14.json
-a---           3/24/2023  3:30 PM           5111 15.json
-a---           3/24/2023  3:30 PM            270 16.json
-a---           3/24/2023  3:30 PM           1902 17.json
-a---           3/24/2023  3:29 PM            142 18.json
-a---           3/24/2023  3:29 PM            178 19.json
-a---           3/24/2023  3:29 PM            648 20.json
-a---           3/24/2023  3:31 PM            434 21.json
-a---           3/24/2023  3:31 PM            354 22.json
-a---           3/24/2023  3:31 PM            119 23.json
-a---           3/24/2023  3:31 PM           4894 24.json
-a---           3/24/2023  3:32 PM            300 26.json
-a---           3/24/2023  3:32 PM            436 27.json
-a---           3/24/2023  3:32 PM           4559 51.json
-a---           3/24/2023  3:32 PM           1648 52.json
-a---           3/24/2023  3:32 PM           2536 53.json
-a---           3/24/2023  3:32 PM           2992 54.json
-a---           3/24/2023  3:32 PM          12220 55.json
-a---           3/24/2023  3:32 PM            447 56.json
-a---           3/24/2023  3:32 PM            305 57.json
-a---           3/24/2023  3:32 PM            124 58.json
-a---           3/24/2023  3:32 PM           2379 59.json
-a---           3/24/2023  3:32 PM            313 60.json




    N° 01 - Tipo de documento
    N° 02 - Tipo de monedas
    N° 03 - Tipo de unidad de medida comercial
    N° 04 - Código de país
    N° 05 - Código de tipos de tributos y otros conceptos
    N° 06 - Código de tipo de documento de identidad
    N° 07 - Código de tipo de afectación del IGV
    N° 08 - Código de tipos de sistema de cálculo del ISC
    N° 09 - Códigos de tipo de nota de crédito electrónica
    N° 10 - Códigos de tipo de nota de débito electrónica
    N° 11 - Códigos de tipo de valor de venta (Resumen diario de boletas y notas)
    N° 12 - Código de documentos relacionados tributarios
    N° 14 - Código de otros conceptos tributarios
    N° 15 - Códigos de elementos adicionales en la factura y boleta electrónica
    N° 16 - Código de tipo de precio de venta unitario
    N° 17 - Código de tipo de operación
    N° 18 - Código de modalidad de transporte
    N° 19 - Código de estado del ítem (resumen diario)
    N° 20 - Código de motivo de traslado
    N° 21 - Código de documentos relacionados (sólo guía de remisión electrónica)
    N° 22 - Código de regimen de percepciones
    N° 23 - Código de regimen de retenciones
    N° 24 - Código de tarifa de servicios públicos
    N° 26 - Tipo de préstamo (créditos hipotecarios)
    N° 27 - Indicador de primera vivienda
    N° 51 - Código de tipo de operación
    N° 52 - Códigos de leyendas
    N° 53 - Códigos de cargos, descuentos y otras deducciones
    N° 54 - Códigos de bienes y servicios sujetos a detracciones
    N° 55 - Código de identificación del concepto tributario
    N° 56 - Código de tipo de servicio público
    N° 57 - Código de tipo de servicio públicos - telecomunicaciones
    N° 58 - Código de tipo de medidor (recibo de luz)
    N° 59 - Medios de Pago
    N° 60 - Código de tipo de dirección




    N° 01 - Tipo de documento
    N° 02 - Tipo de monedas
    N° 03 - Tipo de unidad de medida comercial
    N° 04 - Código de país
    N° 05 - Código de tipos de tributos y otros conceptos
    N° 06 - Código de tipo de documento de identidad
    N° 07 - Código de tipo de afectación del IGV
    N° 08 - Código de tipos de sistema de cálculo del ISC
    N° 09 - Códigos de tipo de nota de crédito electrónica
    N° 10 - Códigos de tipo de nota de débito electrónica
    N° 11 - Códigos de tipo de valor de venta (Resumen diario de boletas y notas)
    N° 12 - Código de documentos relacionados tributarios
    N° 14 - Código de otros conceptos tributarios
    N° 15 - Códigos de elementos adicionales en la factura y boleta electrónica
    N° 16 - Código de tipo de precio de venta unitario
    N° 17 - Código de tipo de operación
    N° 18 - Código de modalidad de transporte
    N° 19 - Código de estado del ítem (resumen diario)
    N° 20 - Código de motivo de traslado
    N° 21 - Código de documentos relacionados (sólo guía de remisión electrónica)
    N° 22 - Código de regimen de percepciones
    N° 23 - Código de regimen de retenciones
    N° 24 - Código de tarifa de servicios públicos
    N° 26 - Tipo de préstamo (créditos hipotecarios)
    N° 27 - Indicador de primera vivienda
    N° 51 - Código de tipo de operación
    N° 52 - Códigos de leyendas
    N° 53 - Códigos de cargos, descuentos y otras deducciones
    N° 54 - Códigos de bienes y servicios sujetos a detracciones
    N° 55 - Código de identificación del concepto tributario
    N° 56 - Código de tipo de servicio público
    N° 57 - Código de tipo de servicio públicos - telecomunicaciones
    N° 58 - Código de tipo de medidor (recibo de luz)
    N° 59 - Medios de Pago
    N° 60 - Código de tipo de dirección
    

## TODO:
- Para hacer fix del select, se puede usar el yarn.lock de billing con la version de antigua de jQuery que no rompe eso.