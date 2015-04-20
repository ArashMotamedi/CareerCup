﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCup.Problems
{
	interface IProblem
	{
		string Id();

		string Statement();

		string DefaultArgs();

		void Run(string args);
	}
}
