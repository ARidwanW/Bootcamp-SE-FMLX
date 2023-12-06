class GameController : IDisposable
{
	private bool disposedValue; //Status whether .Dispose() already called or not
	public Piece piece; //managed object
	public Board board; //managed object
	public MemoryStream memory; //unmanaged object
	
	//Method for check .Dispose() already called or not, 
	//and check release managed object or not
	protected virtual void Dispose(bool disposing) 
	{
		if (!disposedValue) //Check if .Dispose() already called before
		{
			if (disposing) //Release managed object
			{
				//managed object
				piece = null;
				board = null;
			}
			//Unmanaged Object
			memory.Dispose();
			memory = null;
			
			//if this method Called, change disposedValue to true
			disposedValue = true;
		}
	}

	// // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
	~GameController() //Safety Net : if user forget call Dispose()
	{
	//     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		Dispose(false);
	}

	public void Dispose() //Manual
	{
		// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		Dispose(true);
		GC.SuppressFinalize(this); //Surpress Finalizer
	}
}

public class Board
{
}

public class Piece
{
}