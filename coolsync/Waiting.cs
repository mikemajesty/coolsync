using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coolsync
{
    public class Waiting
    {
        private CancellationTokenSource ReferenciarNoCancellationToken { get; set; }
        public CancellationToken Cancel { get; set; }

        public Waiting()
        {
            ReferenciarNoCancellationToken = new CancellationTokenSource();
            Cancel = ReferenciarNoCancellationToken.Token;
        }
        private CancellationToken ReferenciarNoTask()
        {
            try
            {
                CancellationToken ct = ReferenciarNoCancellationToken.Token;
                return ct;
            }
            catch (Exception erro)
            {

                throw new Exception(erro.Message);
            }

        }

        public void CancelTask()
        {
            try
            {
                if (this.Cancel.IsCancellationRequested)
                    ReferenciarNoCancellationToken?.Cancel();

               
            }
            catch (Exception erro)
            {

                throw new Exception(erro.Message);
            }

        }

        public void Start(Action action)
        {
            try
            {
                Control.CheckForIllegalCrossThreadCalls = false;
                new Task(action, Cancel).Start();
            }
            catch (Exception erro)
            {

                throw new Exception(erro.Message);
            }
        }
    }
}
