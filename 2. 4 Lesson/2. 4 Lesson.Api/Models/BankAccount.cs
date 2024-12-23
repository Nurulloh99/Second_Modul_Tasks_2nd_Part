using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._4_Lesson.Api.Models;

public class BankAccount
{
	private int _accountNumber;

	public int AccountNumber
    {
		get { return _accountNumber; }
	}

	// ==================================

	private double _balance = 0;

	public double Balance
    {
		get { return _balance; }
	}

	
	public void Deposit(double balance)
	{
		_balance += balance;

    }
}
