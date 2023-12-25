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
