using System;

namespace Bank
{
	public class RateEventArgs : EventArgs
	{
		public Rate rate;

		public RateEventArgs(Rate rate)
		{
			this.rate = rate;
		}
	}
}