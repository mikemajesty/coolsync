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
            CancellationToken ct = ReferenciarNoCancellationToken.Token;
            return ct;
        }

        public void CancelTask()
        {
            if (this.Cancel.IsCancellationRequested)
                ReferenciarNoCancellationToken?.Cancel();
        }

        public void Start(Action action)
        {
            try
            {
                Control.CheckForIllegalCrossThreadCalls = false;
                new Task(action, Cancel)?.Start();
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }
    }
}
