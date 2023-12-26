# What is Week-4 Day-5
Wuuuihhh, This day is the most busy day, Coz we learn MultiThreading, Async Await, and so on.

>[!NOTE]
>For Cancellation Token, Race Condition, Deadlock, Semaphore, Auto Reset Event will be disscuss in the next week.

<picture>
  <source media="(prefers-color-scheme: dark)" srcset="https://user-images.githubusercontent.com/25423296/163456776-7f95b81a-f1ed-45f7-b7ab-8fa810d529fa.png">
  <source media="(prefers-color-scheme: light)" srcset="https://user-images.githubusercontent.com/25423296/163456779-a8556205-d0a5-45e2-ac17-42d089e3c3f8.png">
  <img alt="Shows an illustrated sun in light mode and a moon with stars in dark mode." src="https://user-images.githubusercontent.com/25423296/163456779-a8556205-d0a5-45e2-ac17-42d089e3c3f8.png">
</picture>

## In Detail
1. **What is MultiThreading**
    * First we must know what the diff between process and thread.

    | Process | Thread |
    |---|---|
    | Different App, Different Process | Unit of process |
    | In general, Isolated | Multiple Thread |

    * It's like the process is the fabric, while the thread is the yarn.

    * Ability of a program to execute multiple tasks simultaneously is called Concurrency.

    * **Case**: Your computer only have 1 Core CPU and wanna using 4 thread. You can use it by something we called Time Slacing

    ```mermaid
    %%{init: { 'logLevel': 'debug', 'theme': 'base', 'gitGraph': {'showBranches': true,'showCommitLabel': false}} }%%
      gitGraph
        commit tag:"1ms"
        commit tag:"1ms"
        branch ThreadA
        commit tag:"3ms"
        branch ThreadB
        commit tag:"2ms"
        branch ThreadC
        commit tag:"4ms"
        checkout main
        merge ThreadC tag:"1ms"
        commit tag:"5ms"
        checkout ThreadB
        merge main tag:"2ms"
        checkout ThreadA
        merge ThreadB tag:"3ms"
        checkout ThreadC
        merge ThreadA tag:"2ms"
        commit tag:"2ms"
    ```

2. **Without Thread**
    * The program will run synchronously
    * One by One
    * Other processes will wait for other processes

      ```
        DoTaskOne();
		    DoTaskTwo();
      ```

3. **With Thread**
    * The program will run Asynchronously
    * Kind of parallel
    * Other processes will run asynchrounously with other process

      ```
        Thread thread1 = new Thread(DoTaskOne);
        Thread thread2 = new Thread(DoTaskTwo);
        
        thread1.Start(); //undeterministic
        thread2.Start();

        thread1.Join();
        thread2.Join();
      ```

4. **How to get return method from other Thread?**

    ```
      int result; //nampung
      int x = 3; //kirim
      int y = 4; //kirim
      Thread myThread = new Thread(() =>
      {
        result = Add(x, y);
      });
      myThread.Start();
    ```

5. **If there's so many thread how we can search for a thread?**
    * We can set the Thread Name.

      ```
        Thread thread = new Thread(DoWork);
        Thread secondThread = new Thread(DoWork);


        thread.Name = "Worker Thread";
        secondThread.Name = "Second Worker Thread";

        static void DoWork()
        {
          Console.WriteLine($"Thread {Thread.CurrentThread.Name} started.");
          Thread.Sleep(2000);
          Console.WriteLine($"Thread {Thread.CurrentThread.Name} finished.");
        }
      ```

6. Remember when we create a thread, **is there any other way to create a thread?**

  * **Simple version**

    ```
      Thread t0 = new Thread(DoWorkSimple);
		  t0.Start();
    ```

  * **Using "new ThreadStart()"**

    ```
      Thread t1 = new Thread(new ThreadStart(DoWorkSimple));
		  t1.Start();
    ```

  * **Using "new ParameterizedThreadStart()"**

    ```
      Thread t2 = new Thread(new ParameterizedThreadStart(DoWorkWithParameter));
		  t2.Start("parameter");
    ```

  * **With additional Stack max size**

    ```
      Thread t3 = new Thread(new ThreadStart(DoWorkSimple), 1024 * 1024 ); // 1 MB stack size
		  t3.Start();
    ```

  * **With additional set the thread name**

    ```
      Thread t4 = new Thread(new ThreadStart(DoWorkSimple));
      t4.Name = "Named Thread";
      t4.Start();
    ```

  * **Using lambda expression**

    ```
      Thread t5 = new Thread(() => DoWorkWithParameter("parameter2"));  // lambda expression
      t5.Start();
    ```

  * **Start with parameter**

    ```
      Thread t6 = new Thread(DoWorkWithParameter);
      t6.Start("Parameter2");
    ```

7. 