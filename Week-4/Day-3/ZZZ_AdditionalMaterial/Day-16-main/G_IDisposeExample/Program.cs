using System;
using System.IO;

public class ResourceHandler : IDisposable
{
	private MemoryStream managedResource;
	private FileStream unmanagedResource;
	private bool disposed = false;

	public ResourceHandler(string filePath)
	{
		managedResource = new MemoryStream();
		unmanagedResource = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
	}

	public void WriteToMemory(string content)
	{
		if (disposed)
		{
			throw new ObjectDisposedException("ResourceHandler");
		}

		byte[] data = System.Text.Encoding.UTF8.GetBytes(content);
		managedResource.Write(data, 0, data.Length);
	}


	protected virtual void Dispose(bool disposing)
	{
		if (!disposed)
		{
			if (disposing)
			{
				if (managedResource != null)
				{
					managedResource.Dispose();
					managedResource = null;
				}
			}
			if (unmanagedResource != null)
			{
				unmanagedResource.Close();
				unmanagedResource = null;
			}

			disposed = true;
		}
	}

	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}
	
	~ResourceHandler()
	{
		Dispose(false);
	}
}