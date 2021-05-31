# Bot.PrecioDolar
Bot que consulta periódicamente el tipo de cambio de 3 casas de camio digitales peruanas (Rextie, InstaKash y DollarHouse) y permite alertar si es que el precio baja a menos de un valor específico.

El proceso de obtener los valores se ejecuta en el método ActualizarPrecioDolar() el cual puede ser llevado a APIs sin mayor complicación dado que sólo se ejecutan peticiones HttpWebRequest.

Si deseas acceder directamente al ejecutable, puedes ingresar a: https://github.com/cesarbravo999/Bot.PrecioDolar/tree/main/Bot.PrecioDolar/bin/Release
