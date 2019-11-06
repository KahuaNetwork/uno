﻿using Windows.Foundation;

namespace Windows.UI.Input
{
	public partial struct ManipulationDelta 
	{
		/// <summary>
		/// A manipulation that does nothing.
		/// This differs to 'default' by having a 'Scale' of 1.
		/// </summary>
		internal static ManipulationDelta Empty { get; } = new ManipulationDelta
		{
			Translation = Point.Zero,
			Rotation = 0,
			Scale = 1,
			Expansion = 0
		};

		public Point Translation;
		public float Scale;
		public float Rotation;
		public float Expansion;

		/// <inheritdoc />
		public override string ToString()
			=> $"x:{Translation.X:N0};y:{Translation.Y:N0};θ:{Rotation:F2};s:{Scale:F2};e:{Expansion:F2}";

		internal ManipulationDelta Add(ManipulationDelta right) => Add(this, right);
		internal static ManipulationDelta Add(ManipulationDelta left, ManipulationDelta right)
			=> new ManipulationDelta
			{
				Translation = new Point(
					left.Translation.X + right.Translation.X,
					left.Translation.Y + right.Translation.Y),
				Rotation = left.Rotation + right.Rotation,
				Scale = left.Scale * right.Scale,
				Expansion = left.Expansion + right.Expansion
			};
	}
}