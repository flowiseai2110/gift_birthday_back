using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Web.Api.Infraestructure
{
    /// <summary>
    /// Provides access to the singleton instance of the Nop engine.
    /// </summary>
    public class EngineContext
    {
   

        /// <summary>
        /// Create a static instance of the Pro engine.
        /// </summary>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static IEngine Create()
        {
            //create NopEngine as engine
            return Singleton<IEngine>.Instance ?? (Singleton<IEngine>.Instance = new ProEngine());
        }

        /// <summary>
        /// Sets the static engine instance to the supplied engine. Use this method to supply your own engine implementation.
        /// </summary>
        /// <param name="engine">The engine to use.</param>
        /// <remarks>Only use this method if you know what you're doing.</remarks>
        public static void Replace(IEngine engine)
        {
            Singleton<IEngine>.Instance = engine;
        }
        
      

   

        /// <summary>
        /// Gets the singleton Nop engine used to access Pro services.
        /// </summary>
        public static IEngine Current
        {
            get
            {
                if (Singleton<IEngine>.Instance == null)
                {
                    Create();
                }

                return Singleton<IEngine>.Instance;
            }
        }

       


    }
}
