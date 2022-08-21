using System;
using System.Collections.Generic;

public sealed class ShopScreen {
	private bool mShouldExit;
	private readonly Hero mHero;

	public ShopScreen(Hero hero) {
		mHero = hero;
		mShouldExit = false;
	}

	public void Go() {
		var menuDict = new Dictionary<int, Tuple<string, Action>> {
			[1] = Tuple.Create<string, Action>("Gold shop", _ExecuteGoldShop),
			[2] = Tuple.Create<string, Action>("Experience shop", _ExecuteExperienceShop),
			[3] = Tuple.Create<string, Action>("Return", _ExecuteReturn),
			};

		Console.Clear();
		while(!mShouldExit) {
			Console.WriteLine("Where do you want to go now?");
			foreach(var kvp in menuDict) {
				Console.WriteLine($"{kvp.Key}. {kvp.Value.Item1}");
			}

			string input = Console.ReadLine() ?? string.Empty;
			var menuAction = InputParser.Parse(input, menuDict, _ExecuteInvalid);
			menuAction();
		}
	}

	private void _ExecuteGoldShop() {
		Market MK = new Market(mHero);
		MK.Shop();
		Console.Clear();
	}

	private void _ExecuteExperienceShop() {
		ExpMarket EM = new ExpMarket(mHero);
		EM.Shop();
		Console.Clear();
	}

	private void _ExecuteReturn() {
		Console.Clear();
		mShouldExit = true;
	}

	private void _ExecuteInvalid() {
		Console.Clear();
		Console.WriteLine("Invalid shop\n");
	}
}
