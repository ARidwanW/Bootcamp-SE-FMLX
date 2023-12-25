# What is Week-4 Day-4
In Day 4 of Week 4, We learn conditional compilation as we look a bit in day 3, then Debugger tutorial (it's practical, so i need more time to write in this readme, alternatively you can see in another resource), Hot Reload, Debug and Trace, Console Trace Listeners and Trace listerner, also XML Documentation.

<picture>
  <source media="(prefers-color-scheme: dark)" srcset="https://user-images.githubusercontent.com/25423296/163456776-7f95b81a-f1ed-45f7-b7ab-8fa810d529fa.png">
  <source media="(prefers-color-scheme: light)" srcset="https://user-images.githubusercontent.com/25423296/163456779-a8556205-d0a5-45e2-ac17-42d089e3c3f8.png">
  <img alt="Shows an illustrated sun in light mode and a moon with stars in dark mode." src="https://user-images.githubusercontent.com/25423296/163456779-a8556205-d0a5-45e2-ac17-42d089e3c3f8.png">
</picture>

## In Detail
1. **Conditional Compilation**
    * A bit fresh of what it is [here](https://github.com/ARidwanW/Bootcamp-SE-FMLX/tree/main/Week-4/Day-3#:~:text=In%20Detail-,Conditional%20Compilation,-it%27s%20define%20what)
    * Assign `<DefineConstant>` on the .csproj inside `<PropertyGroup>`
    * Assign using `#define`

2. **Hot Reload**
    * A feature that .NET has for see update real time when the codes is changed. 
    * To use, you can run below command:

        ```
            dotnet watch

            or

            dotnet watch run
        ```
    
3. **Error**

    ```mermaid
    graph TD;
    Error-->A[Logical Error];
    Error-->B[Compilation Error];
    Error-->C[Runtime Error];
    A-->Debugger;
    Debugger-->D[Tool Debugger];
    Debugger-->E[Console.WriteLine];
    Debugger-->F[Log];
    ```

4. **LOG**

    ```mermaid
    graph TD;
    Log-->A[Log Level<br>Severity];
    Log-->B[Internal<br>Microsoft];
    Log-->External;
    A-->C[Critical/Fatal];
    C-->CRASH;
    A-->Error;
    Error-->D[TRY & CATCH];
    A-->Warning;
    Warning-->F[Possibility of Error / even Fatal];
    A-->Info;
    Info-->G[As required / as expected / normal];
    A-->Debug;
    Debug-->H[Development Purpose];
    A-->Trace;
    Trace-->H;
    A-->None;
    B-->Debug;
    B-->Trace;
    External-->NLog;
    External-->Log4Net;
    External-->I[JLog for Java];
    ```

5. **Debug & Trace**
    * They're log level for development purpose.
    * Any External Logging Framework has all loglevel.
    * But internal or Microsoft only has them.
    * We only can see the output in Debug Console or if you are using TextWriterTraceListener, it can be write to a file.
    * And You must run it from Debug, NOT dotnet run or dotnet build

        ```mermaid
        graph TD;
        Debug-->A[Debug.WriteLine];
        Trace-->B[Trace.WriteLine];
        Trace-->C[ConsoleTraceListener];
        Trace-->D[TextWriterTraceListener];
        ```

        * **ConsoleTraceListener**

        ```
            ConsoleTraceListener consoleTraceListener = new ConsoleTraceListener();
            Trace.Listeners.Add(consoleTraceListener);
        ```

        * **TextWriterTraceListener**

        ```
            Trace.Listeners.Clear();
			using(TextWriterTraceListener traceListener = new TextWriterTraceListener("myTraceOutput.txt")) 
			{
				Trace.Listeners.Add(traceListener);
			
				Trace.Assert(true, "This is a trace false.");
				Debug.Assert(false, "This is a DEBUG FALSE.");
				Trace.WriteLine("This is a trace statement.");
			
				traceListener.Flush();
				traceListener.Close();
			}
        ```

6. **XML Documentation**
    * When you hover a variable or a method or a class, there will be a summary of the variable, method, or class.
    * To give them summary, we can use XML Documentation.

        ```
            /// <summary>
            /// Adds two numbers together and returns the result.
            /// </summary>
            /// <param name="a">The first number to add.</param>
            /// <param name="b">The second number to add.</param>
            /// <returns>The sum of a and b</returns>
            public static double Add(double a, double b)
            {
                return a + b;
            }
        ```

