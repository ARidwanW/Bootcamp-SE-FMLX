# What is Day-8
More advance on C# :slightly_smiling_face: In Day-8 we learn about EventArgs, Event Handler Generic, Game Controller, Exception, Exception handler, and so on.

<picture>
  <source media="(prefers-color-scheme: dark)" srcset="https://user-images.githubusercontent.com/25423296/163456776-7f95b81a-f1ed-45f7-b7ab-8fa810d529fa.png">
  <source media="(prefers-color-scheme: light)" srcset="https://user-images.githubusercontent.com/25423296/163456779-a8556205-d0a5-45e2-ac17-42d089e3c3f8.png">
  <img alt="Shows an illustrated sun in light mode and a moon with stars in dark mode." src="https://user-images.githubusercontent.com/25423296/163456779-a8556205-d0a5-45e2-ac17-42d089e3c3f8.png">
</picture>

## In Detail
1. Event:
  * a keyword in delegate
  * it makes delegate cannot using "=", instead using "+=" or "-=".
  * so it makes sure that the delegate cannot be reassign

  ```
    // out of class or in class
    public delegate void Listener();

    public event Listener onUpdate;
  ```

2. Action: 
  * built-in delegate
  * up to 16 parameter
  * void
  * using generic
  * no need to declare delegate

  ```
    // using 2 parameter
    public event Action<int, bool> onUpdated;
  ```

3. func:
  * built-in delegate
  * up to 16 parameter
  * return type
  * using generic, with the last generic is the return type
  * no need to declare delegate

  ```
    public event Func<int, int, bool> onStatus;

    // int, int is parameter
    // bool in return type
  ```

4. Event Handler:
  * delegate with send the publisher to subscriber
  * so the subscriber will know how send the notification

  ```
    // in the library
    public delegate void EvenHandler(object? sender, EventArgs e)

    // EventArgs e is the data (but it's empty)

    // how to declare
    public event EventHandler subs;

    // how to invoke
    subs?.Invoke(this, EventArgs.Empty);
  ```

5. Event Handler Generic
  * `EventHandler<T>`

  * In Library:

  ```
    public delegate void EventHandler<T>(Object? sender, T e)
  ```

  * to create the data

  ```
    public event EventHandler<DataEvent> subs;

    class DataEvent : EventArgs {
      public string name;
      public string information;
      public int code;
    }
  ```

  * to invoke the data

  ```
    public void SendNotif()
    {
          // * Name == object sender
      subs?.Invoke(Name, new DataEvent { 
        code = 1, 
        information = "informasi", 
        name = "nama"
      });
    }
  ```

  * in subscriber

  ```
    public void GetNotif(object sender, DataEvent e)
    {
      Console.WriteLine($"Subscriber got notified from {sender} with data : {e.code} {e.name} {e.information}");
    }
  ```

6. Exception and Exception Handling
  * Exception is when your program crash because of something, this will return Exception, before we know like StackOverflowException, IndexOutOfRangeException, and so on
  * to handling we use try, catch and finally

  ```
    try
    {
      //.. your code
    }
    catch (Exception e)
    {
      //.. your code for the error
      Console.WriteLine(e.Message);
    }
    finally
    {
      // this will execute even there's exception or no exception
      // finally use to release unmanaged resource
      // coz garbage collector only remove managed resource
    }
  ```

7. Unmanaged Resource
  * DB
  * file
  * http request
  * API
  * SMTP