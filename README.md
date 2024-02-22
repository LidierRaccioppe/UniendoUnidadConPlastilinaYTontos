# Rueda la bola Desde Github

## Método `SpawnColumnsRandomly()`

Este método se encarga de generar columnas en posiciones aleatorias dentro del juego. Primero, determina el número de columnas a generar, que es un número aleatorio entre `minPickups` y `maxPickups + 1`. Luego, para cada columna a generar, calcula una posición aleatoria dentro de un rango específico y crea una instancia de la columna en esa posición.
Para asi molestar al jugador al darle mas restricciones.

```csharp
void SpawnColumnsRandomly()
{
    int numColumnsToSpawn = Random.Range(minPickups, maxPickups + 1);

    for (int i = 0; i < numColumnsToSpawn; i++)
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-10f, 10f), 0.5f, Random.Range(-10f, 10f));
        Instantiate(ColumnsPrefab, spawnPosition, Quaternion.identity);
    }
}
```

## Método `SpawnEnemy()`

Este método se encarga de generar un nuevo enemigo en la misma posición que el objeto actual. Utiliza la función `Instantiate` para crear una nueva instancia del prefab del enemigo.
Por si el jugador es demasiado malo y tarda mas para asi aumentarle la dificultad, por si ante una mayor dificultad se motiva.
```csharp
void SpawnEnemy()
{
    Instantiate(enemyPrefab, transform.position, Quaternion.identity);
}
```

## Método `OnTriggerEnter(Collider other)`

Este método se activa cuando el objeto entra en contacto con otro objeto. Si el objeto con el que se ha entrado en contacto tiene la etiqueta "Enemy" o "Columns", la velocidad del jugador se reduce en 1.
Aunque no aparece tambien es con los collectibles para aumentar el texto de cuantos tiene y reducirle los que le faltan, comprueba si el jugador toco a un enemigo para bajarle la velocidad, o u columna igualmente para bajarle la velocidad.
```csharp
void OnTriggerEnter(Collider other)
{
    if (other.gameObject.CompareTag("Enemy"))
    {
        speed = speed -1;
    }
    if (other.gameObject.CompareTag("Columns"))
    {
        speed = speed -1;
    }
}
```

## Método `CountPickupsLeft(string tag = "PickUp")`

Este método cuenta el número de objetos con la etiqueta "PickUp" que quedan en la escena. Devuelve el número de estos objetos.
Para saber cuantos collectibles le faltan al jugador.
```csharp
int CountPickupsLeft(string tag = "PickUp")
{
    GameObject[] pickups = GameObject.FindGameObjectsWithTag("PickUp");
    int pickupCount = pickups.Length;
    return pickupCount;
}
```




