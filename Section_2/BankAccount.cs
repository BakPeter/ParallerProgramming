namespace Section_2
{
    public class BankAccount
    {
        //public object padlock = new object();
     
        private int balance;
        public int Balance { get => balance; private set => balance = value; }

        public void Deposit(int amount)
        {
            //lock (padlock)
            //{
            //    // += is really two operations
            //    // op1 is temp <- get_Balance() + amount
            //    // op2 is set_Balance(temp)
            //    // something can happen _between_ op1 and op2
            //    Balance += amount;
            //}

            Interlocked.Add(ref balance, amount);
        }

        public void Withdraw(int amount)
        {
            //lock (padlock)
            //{
            //    Balance -= amount;
            //}


            Interlocked.Add(ref balance, -amount);
        }

        // show interlocked methods here

        // Interlocked.MemoryBarrier is a wrapper for Thread.MemoryBarrier
        // only required on memory systems that have weak memory ordering (e.g., Itanium)
        // prevents the CPU from reordering the instructions such that those before the barrier
        // execute after those after
    }
}
