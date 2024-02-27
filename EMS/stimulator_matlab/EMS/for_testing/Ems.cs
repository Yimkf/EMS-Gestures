/*
* MATLAB Compiler: 8.5 (R2022b)
* Date: Mon Dec 25 18:50:10 2023
* Arguments:
* "-B""macro_default""-W""dotnet:EMS,Ems,4.0,private,version=1.0""-T""link:lib""-d""C:\Use
* rs\YKF\Desktop\m\EMS\for_testing""-v""class{Ems:C:\Users\YKF\Desktop\m\flower.m,C:\Users
* \YKF\Desktop\m\gun.m,C:\Users\YKF\Desktop\m\lever.m,C:\Users\YKF\Desktop\m\scissors.m,C:
* \Users\YKF\Desktop\m\shield.m,C:\Users\YKF\Desktop\m\spiderman.m,C:\Users\YKF\Desktop\m\
* stapler.m}"
*/
using System;
using System.Reflection;
using System.IO;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;

#if SHARED
[assembly: System.Reflection.AssemblyKeyFile(@"")]
#endif

namespace EMS
{

  /// <summary>
  /// The Ems class provides a CLS compliant, MWArray interface to the MATLAB functions
  /// contained in the files:
  /// <newpara></newpara>
  /// C:\Users\YKF\Desktop\m\flower.m
  /// <newpara></newpara>
  /// C:\Users\YKF\Desktop\m\gun.m
  /// <newpara></newpara>
  /// C:\Users\YKF\Desktop\m\lever.m
  /// <newpara></newpara>
  /// C:\Users\YKF\Desktop\m\scissors.m
  /// <newpara></newpara>
  /// C:\Users\YKF\Desktop\m\shield.m
  /// <newpara></newpara>
  /// C:\Users\YKF\Desktop\m\spiderman.m
  /// <newpara></newpara>
  /// C:\Users\YKF\Desktop\m\stapler.m
  /// </summary>
  /// <remarks>
  /// @Version 1.0
  /// </remarks>
  public class Ems : IDisposable
  {
    #region Constructors

    /// <summary internal= "true">
    /// The static constructor instantiates and initializes the MATLAB Runtime instance.
    /// </summary>
    static Ems()
    {
      if (MWMCR.MCRAppInitialized)
      {
        try
        {
          Assembly assembly= Assembly.GetExecutingAssembly();

          string ctfFilePath= assembly.Location;

		  int lastDelimiter = ctfFilePath.LastIndexOf(@"/");

	      if (lastDelimiter == -1)
		  {
		    lastDelimiter = ctfFilePath.LastIndexOf(@"\");
		  }

          ctfFilePath= ctfFilePath.Remove(lastDelimiter, (ctfFilePath.Length - lastDelimiter));

          string ctfFileName = "EMS.ctf";

          Stream embeddedCtfStream = null;

          String[] resourceStrings = assembly.GetManifestResourceNames();

          foreach (String name in resourceStrings)
          {
            if (name.Contains(ctfFileName))
            {
              embeddedCtfStream = assembly.GetManifestResourceStream(name);
              break;
            }
          }
          mcr= new MWMCR("",
                         ctfFilePath, embeddedCtfStream, true);
        }
        catch(Exception ex)
        {
          ex_ = new Exception("MWArray assembly failed to be initialized", ex);
        }
      }
      else
      {
        ex_ = new ApplicationException("MWArray assembly could not be initialized");
      }
    }


    /// <summary>
    /// Constructs a new instance of the Ems class.
    /// </summary>
    public Ems()
    {
      if(ex_ != null)
      {
        throw ex_;
      }
    }


    #endregion Constructors

    #region Finalize

    /// <summary internal= "true">
    /// Class destructor called by the CLR garbage collector.
    /// </summary>
    ~Ems()
    {
      Dispose(false);
    }


    /// <summary>
    /// Frees the native resources associated with this object
    /// </summary>
    public void Dispose()
    {
      Dispose(true);

      GC.SuppressFinalize(this);
    }


    /// <summary internal= "true">
    /// Internal dispose function
    /// </summary>
    protected virtual void Dispose(bool disposing)
    {
      if (!disposed)
      {
        disposed= true;

        if (disposing)
        {
          // Free managed resources;
        }

        // Free native resources
      }
    }


    #endregion Finalize

    #region Methods

    /// <summary>
    /// Provides a void output, 0-input MWArrayinterface to the flower MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Master9.SetChannelDelay(3,200e-6);
    /// </remarks>
    ///
    public void flower()
    {
      mcr.EvaluateFunction(0, "flower", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the flower MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Master9.SetChannelDelay(3,200e-6);
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] flower(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "flower", new MWArray[]{});
    }


    /// <summary>
    /// Provides a void output, 0-input MWArrayinterface to the gun MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 1:thumb 2:index 3:middle 4:ring 5:pinky 
    /// </remarks>
    ///
    public void gun()
    {
      mcr.EvaluateFunction(0, "gun", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the gun MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 1:thumb 2:index 3:middle 4:ring 5:pinky 
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] gun(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "gun", new MWArray[]{});
    }


    /// <summary>
    /// Provides a void output, 0-input MWArrayinterface to the lever MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Master9.SetChannelDelay(3,200e-6);
    /// </remarks>
    ///
    public void lever()
    {
      mcr.EvaluateFunction(0, "lever", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the lever MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Master9.SetChannelDelay(3,200e-6);
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] lever(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "lever", new MWArray[]{});
    }


    /// <summary>
    /// Provides a void output, 0-input MWArrayinterface to the scissors MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Master9.SetChannelDelay(3,200e-6);
    /// </remarks>
    ///
    public void scissors()
    {
      mcr.EvaluateFunction(0, "scissors", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the scissors MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Master9.SetChannelDelay(3,200e-6);
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] scissors(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "scissors", new MWArray[]{});
    }


    /// <summary>
    /// Provides a void output, 0-input MWArrayinterface to the shield MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Master9.SetChannelDelay(3,200e-6);
    /// </remarks>
    ///
    public void shield()
    {
      mcr.EvaluateFunction(0, "shield", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the shield MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Master9.SetChannelDelay(3,200e-6);
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] shield(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "shield", new MWArray[]{});
    }


    /// <summary>
    /// Provides a void output, 0-input MWArrayinterface to the spiderman MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Master9.SetChannelDelay(3,200e-6);
    /// </remarks>
    ///
    public void spiderman()
    {
      mcr.EvaluateFunction(0, "spiderman", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the spiderman MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Master9.SetChannelDelay(3,200e-6);
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] spiderman(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "spiderman", new MWArray[]{});
    }


    /// <summary>
    /// Provides a void output, 0-input MWArrayinterface to the stapler MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Master9.SetChannelDelay(3,200e-6);
    /// </remarks>
    ///
    public void stapler()
    {
      mcr.EvaluateFunction(0, "stapler", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the stapler MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Master9.SetChannelDelay(3,200e-6);
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] stapler(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "stapler", new MWArray[]{});
    }



    /// <summary>
    /// This method will cause a MATLAB figure window to behave as a modal dialog box.
    /// The method will not return until all the figure windows associated with this
    /// component have been closed.
    /// </summary>
    /// <remarks>
    /// An application should only call this method when required to keep the
    /// MATLAB figure window from disappearing.  Other techniques, such as calling
    /// Console.ReadLine() from the application should be considered where
    /// possible.</remarks>
    ///
    public void WaitForFiguresToDie()
    {
      mcr.WaitForFiguresToDie();
    }



    #endregion Methods

    #region Class Members

    private static MWMCR mcr= null;

    private static Exception ex_= null;

    private bool disposed= false;

    #endregion Class Members
  }
}
