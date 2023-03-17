using System;

namespace EventsInCsharp
{
    //delegate for notification event
    public delegate void Notify();
    class ProcessBusinessLogic
    {
        public event Notify? ProcessCompleted;


        /// <summary>
        /// This method denotes the start of the process.
        /// </summary>
        /// <returns>void</returns>
        public void StartProcess()
        {
            Console.WriteLine("Process Started!");
            // some code here...
            OnProcessCompleted();
        }

        /// <summary>
        /// This methods invokes the event on completion of process
        /// </summary>
        /// <remarks>The method is virtual and can be overridden</remarks>
        /// <returns>void</returns>
        protected virtual void OnProcessCompleted() 
        {
            //if ProcessCompleted is not null then call delegate
            ProcessCompleted?.Invoke();
        }

        /// <summary>
        /// This method is the event handler for notification event
        /// </summary>
        /// <returns>void</returns>
        public static void bl_ProcessCompleted()
        {
            Console.WriteLine("Method Invoked");
        }

    }

    class Program
    {

        public static void Main()
        {
            ProcessBusinessLogic processBusinessLogic = new ProcessBusinessLogic();

            //adding event handler method bl_ProcessCompleted to handle notify event
            processBusinessLogic.ProcessCompleted += ProcessBusinessLogic.bl_ProcessCompleted;
            processBusinessLogic.StartProcess();
        }
    }
}