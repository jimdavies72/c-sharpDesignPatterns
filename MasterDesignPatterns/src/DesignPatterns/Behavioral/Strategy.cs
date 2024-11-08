// Strategy Pattern

// The Strategy Pattern is used to pass different algorithms or behaviours to an object

namespace MasterDesignPatterns.src.DesignPatterns
{
  // Good example...
  public interface ICompressor
  {
    void Compress();
  }

  public interface IOverlay
  {
    void Apply();
  }

  public class MOVCompressor : ICompressor
  {
    public void Compress()
    {
      // Compressing logic
      Console.WriteLine($"Compressing in MOV format");
    }
  }

  public class MP4Compressor : ICompressor
  {
    public void Compress()
    {
      // Compressing logic
      Console.WriteLine($"Compressing in MP4 format");
    }
  }

  public class WEBMCompressor : ICompressor
  {
    public void Compress()
    {
      // Compressing logic
      Console.WriteLine($"Compressing in WEBM format");
    }
  }

  public class BlackAndWhiteOverlay : IOverlay
  {
    public void Apply()
    {
      // Applying Black and White Overlay
      Console.WriteLine($"Applying Black and White Overlay");
    }
  }

  public class BlurOverlay : IOverlay
  {
    public void Apply()
    {
      // Applying Blur Overlay
      Console.WriteLine($"Applying Blur Overlay");
    }
  } 

  public class NoneOverlay : IOverlay
  {
    public void Apply()
    {
      // Applying None Overlay
      Console.WriteLine($"Applying No Overlay");
    }
  }

  public class VideoStorge
  {
    private ICompressor compressor;
    private IOverlay overlay; 

    public VideoStorge(ICompressor compressor, IOverlay overlay)
    {
      this.compressor = compressor;
      this.overlay = overlay;
    }

    public void SetCompression(ICompressor compressor)
    {
      this.compressor = compressor;
    }

    public void SetOverlay(IOverlay overlay)  
    {
      this.overlay = overlay;
    }

    public void Store(string filename)
    {
      compressor.Compress();
      overlay.Apply();

      Console.WriteLine($"\nStored {filename}.{compressor} with {overlay} overlay\n");
    }
  }


  // Bad example...

  // public enum Compressors
  // {
  //   MOV,
  //   MP4,
  //   WEBM
  // }

  // public enum Overlays
  // {
  //   None,
  //   BlackAndWhite,
  //   Blur
  // }

  // public class VideoStorge
  // {
  //   private Compressors compressor;
  //   private Overlays overlay;

  //   public VideoStorge(Compressors compressor, Overlays overlay = Overlays.None)
  //   {
  //     this.compressor = compressor;
  //     this.overlay = overlay;
  //   }

  //   public void SetCompression(Compressors compressor)
  //   {
  //     this.compressor = compressor;
  //   }

  //   public void SetOverlay(Overlays overlay)
  //   {
  //     this.overlay = overlay;
  //   }

  //   public void Store(string filename)
  //   {
  //     // Compressing logic
  //     if (compressor == Compressors.MOV)  
  //     {
  //       Console.WriteLine($"Storing in MOV format");
  //     } else if (compressor == Compressors.MP4) 
  //     {
  //       Console.WriteLine($"Storingin MP4 format");
  //     } else if (compressor == Compressors.WEBM) 
  //     {
  //       Console.WriteLine($"Storing in WEBM format");
  //     }

  //     // Overlay logic
  //     if (overlay == Overlays.None) 
  //     {
  //       Console.WriteLine("No overlay");
  //     } else if (overlay == Overlays.BlackAndWhite) 
  //     {
  //       Console.WriteLine("Black and white overlay");
  //     } else if (overlay == Overlays.Blur) 
  //     {
  //       Console.WriteLine("Blur overlay");
  //     }

  //     Console.WriteLine($"\nStored {filename}.{compressor} with {overlay} overlay\n");
  //   }
  // }
}