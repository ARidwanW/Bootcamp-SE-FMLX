# What is Day-9
This is the last day of the second week, because tomorrow and next week will be exam and individual project. so in day 9 we continue the try catch with finally (but i already explain a bit yesterday), then collection of data like array, list, and hashset.

<picture>
  <source media="(prefers-color-scheme: dark)" srcset="https://user-images.githubusercontent.com/25423296/163456776-7f95b81a-f1ed-45f7-b7ab-8fa810d529fa.png">
  <source media="(prefers-color-scheme: light)" srcset="https://user-images.githubusercontent.com/25423296/163456779-a8556205-d0a5-45e2-ac17-42d089e3c3f8.png">
  <img alt="Shows an illustrated sun in light mode and a moon with stars in dark mode." src="https://user-images.githubusercontent.com/25423296/163456779-a8556205-d0a5-45e2-ac17-42d089e3c3f8.png">
</picture>

## In Detail
1. `Array`
    * Fix Size
    * Type Safety
    * Must set Size

    ```
        // 4 data
        int[] myArray = new int[4];
    ```

    * Array.Resize() --> create a new room, not really resize the room
    * object[] --> not type safety array

2. `ArrayList`
    * dynamic type --> must know the index and the data type
    * Not type safety --> every data type can be insert
    * the data is object --> need unboxing

    ```
        ArrayList myList = new ArrayList();
        myList.Add(3)

        // to retrieve
        foreach(i in myList)
        {
            // must check the data type
            int result = (int) i;
        }
    ```
    
    * better avoid

3. `List<T`>
    * dynamic
    * access value with index
    * type safety

    ```
        List<int> myInt = new List<int>();

        // to assign 
        List<int> myInt = new List<int>(){1, 2, 3};

        // or
        myInt.Add(3);

        // retrieve
        int result = myInt[0];
    ```

4. `HashSet<T>`
    * dynamic
    * type safety
    * index access
    * element unique

    * can using:
        * intersectWith()
        * unionWith()
        * exceptWith()
        * isSupset(HashSet2)
        * isSubset(HashSet2)