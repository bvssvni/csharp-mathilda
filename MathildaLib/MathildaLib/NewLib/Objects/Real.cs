using System;
using System.Collections.Generic;

namespace MathildaLib
{
	public class Real : Algebra<Real>
	{
		public List<Product> AboveProducts;
		public List<Product> BelowProducts;

		public class Product {
			public List<VariableExponent> Items;
			public double Scalar;

			public Product Multiply (Product b) {
				var a = this;
				var p = new Product () {
					Scalar = a.Scalar * b.Scalar,
					Items = new List<VariableExponent> ()
				};
				if (p.Scalar == 0.0) {
					return p;
				}

				int na = a.Items.Count;
				int nb = b.Items.Count;
				int ia = 0;
				int ib = 0;
				while (ia < na || ib < nb) {
					var pa = ia < na ? a.Items [ia] : null;
					var pb = ib < nb ? b.Items [ib] : null;
					var cmp = VariableExponent.CompareVariable (pa, pb);
					if (cmp == -1) {
						p.Items.Add (pa.Copy ());
						ia++;
					} else if (cmp == 1) {
						p.Items.Add (pb.Copy ());
						ib++;
					} else {
						var exponent = pa.Exponent + pb.Exponent;
						if (exponent != 0) {
							p.Items.Add (new VariableExponent () {
								Variable = pa.Variable,
								Exponent = exponent
							});
						}
						ia++;
						ib++;
					}
				}

				return p;
			}

			public List<VariableExponent> CopyItems () {
				int n = Items.Count;
				var list = new List<VariableExponent> (n);
				for (int i = 0; i < n; i++) {
					list.Add (new VariableExponent () {
						Variable = Items [i].Variable,
						Exponent = Items [i].Exponent
					});
				}

				return list;
			}

			public Product Copy () {
				return new Product () {
					Scalar = this.Scalar,
					Items = this.CopyItems ()
				};
			}

			public Product Inverted () {
				var copy = this.Copy ();
				copy.Scalar = 1.0 / copy.Scalar;
				int n = copy.Items.Count;
				for (int i = 0; i < n; i++) {
					copy.Items [i].Exponent = -copy.Items [i].Exponent;
				}

				return copy;
			}

			public Product Negative () {
				var copy = this.Copy ();
				copy.Scalar = -copy.Scalar;
				return copy;
			}

			public static int CompareVariable (Product a, Product b) {
				if (a == null && b == null) {return 0;}
				if (a == null) {return 1;}
				if (b == null) {return -1;}

				var cmp = 0;
				cmp = a.Items.Count.CompareTo (b.Items.Count);
				if (cmp != 0) {
					return cmp;
				}

				int n = a.Items.Count;
				for (int i = 0; i < n; i++) {
					var ai = a.Items [i];
					var bi = b.Items [i];
					cmp = ai.Variable.CompareTo (bi);
					if (cmp != 0) {
						return cmp;
					}
				}

				return 0;
			}

			public static int CompareVariableExponent (Product a, Product b) {
				if (a == null && b == null) {return 0;}
				if (a == null) {return 1;}
				if (b == null) {return -1;}
				
				var cmp = 0;
				cmp = a.Items.Count.CompareTo (b.Items.Count);
				if (cmp != 0) {
					return cmp;
				}
				
				int n = a.Items.Count;
				for (int i = 0; i < n; i++) {
					var ai = a.Items [i];
					var bi = b.Items [i];
					cmp = VariableExponent.CompareVariableExponent (ai, bi);
					if (cmp != 0) {
						return cmp;
					}
				}
				
				return 0;
			}

			public class VariableExponent {
				public string Variable;
				public double Exponent;

				public VariableExponent Copy () {
					return new VariableExponent () {
						Variable = this.Variable,
						Exponent = this.Exponent
					};
				}

				public static int CompareVariable (VariableExponent a, VariableExponent b) {
					if (a == null && b == null) {return 0;}
					if (a == null) {return 1;}
					if (b == null) {return -1;}

					return a.Variable.CompareTo (b.Variable);
				}

				public static int CompareVariableExponent (VariableExponent a, VariableExponent b) {
					if (a == null && b == null) {return 0;}
					if (a == null) {return 1;}
					if (b == null) {return -1;}

					var cmp = 0;
					cmp = a.Variable.CompareTo (b.Variable);
					if (cmp != 0) {
						return cmp;
					}
					
					cmp = a.Exponent.CompareTo (b.Exponent);
					if (cmp != 0) {
						return cmp;
					}
					
					return 0;
				}
			}
		}

		private static List<Product> CopyProductList (List<Product> list) {
			int n = list.Count;
			var copy = new List<Product> (n);
			for (int i = 0; i < n; i++) {
				copy.Add (list [i].Copy ());
			}

			return copy;
		}

		public Real Copy () {
			return new Real () {
				AboveProducts = CopyProductList (this.AboveProducts),
				BelowProducts = CopyProductList (this.BelowProducts)
			};
		}

		public override Real Inverted () {
			return new Real () {
				AboveProducts = CopyProductList (this.BelowProducts),
				BelowProducts = CopyProductList (this.AboveProducts)
			};
		}

		public override Real Negative () {
			var r = this.Copy ();
			int n = r.AboveProducts.Count;
			for (int i = 0; i < n; i++) {
				var p = r.AboveProducts [i];
				r.AboveProducts [i] = p.Negative ();
			}

			return r;
		}

		public static Real Scalar (double val) {
			return new Real () {
				AboveProducts = new List<Product> () {
					new Product () {
						Scalar = val,
						Items = new List<Product.VariableExponent> ()
					}
				},
				BelowProducts = new List<Product> () {
					new Product () {
						Scalar = 1,
						Items = new List<Product.VariableExponent> ()
					}
				}
			};
		}

		public static Real Variable (string val) {
			return new Real () {
				AboveProducts = new List<Product> () {
					new Product () {
						Scalar = 1,
						Items = new List<Product.VariableExponent> () {
							new Product.VariableExponent () {
								Variable = val,
								Exponent = 1
							}
						}
					}
				},
				BelowProducts = new List<Product> () {
					new Product () {
						Scalar = 1,
						Items = new List<Product.VariableExponent> ()
					}
				}
			};
		}

		private bool IsIdentity (List<Product> list) {
			if (list.Count != 1) {return false;}
			if (list [0].Items.Count != 0) {return false;}
			if (list [0].Scalar != 1) {return false;}

			return true;
		}

		private static string ProductListToString (List<Product> list) {
			int n = list.Count;
			var strb = new System.Text.StringBuilder ();
			for (int i = 0; i < n; i++) {
				strb.Append ("+");
				var product = list [i];
				strb.Append (product.Scalar.ToString (System.Globalization.CultureInfo.InvariantCulture));
				var items = product.Items;
				int m = items.Count;
				for (int j = 0; j < m; j++) {
					strb.Append ("*");
					var variableExponent = items [j];
					strb.Append (variableExponent.Variable);
					strb.Append ("^");
					strb.Append (variableExponent.Exponent);
				}
			}

			return strb.ToString ();
		}

		private static string ProductListToStringSimplified (List<Product> list) {
			int n = list.Count;
			var strb = new System.Text.StringBuilder ();
			for (int i = 0; i < n; i++) {
				var product = list [i];
				var isOne = product.Scalar == 1 || product.Scalar == -1;
				if (i != 0 && product.Scalar >= 0) {
					strb.Append ("+");
				}
				if (!isOne) {
					strb.Append (product.Scalar.ToString (System.Globalization.CultureInfo.InvariantCulture));
				}
				if (product.Scalar == -1) {
					strb.Append ("-");
				}

				var items = product.Items;
				int m = items.Count;
				for (int j = 0; j < m; j++) {
					if (!isOne || j != 0) {
						strb.Append ("*");
					}

					var variableExponent = items [j];
					strb.Append (variableExponent.Variable);
					if (variableExponent.Exponent != 1) {
						strb.Append ("^");
						strb.Append (variableExponent.Exponent);
					}
				}
			}

			return strb.ToString ();
		}

		private string ToStringNormal ()
		{
			var strb = new System.Text.StringBuilder ();
			strb.Append ("(");
			strb.Append (ProductListToString (this.AboveProducts));
			strb.Append (")/(");
			strb.Append (ProductListToString (this.BelowProducts));
			strb.Append (")");
			return strb.ToString ();
		}

		private string ToStringSimplified()
		{
			var aboveIsIdentity = IsIdentity (this.AboveProducts);
			var belowIsIdentity = IsIdentity (this.BelowProducts);
			var aboveZero = this.AboveProducts.Count == 0;
			var belowZero = this.BelowProducts.Count == 0;
			if (aboveZero) {
				return "0";
			} else if (belowZero) {
				return "(" + ProductListToStringSimplified (this.AboveProducts) + ")/0";
			}
			if (aboveIsIdentity && belowIsIdentity) {
				return "1";
			} else if (aboveIsIdentity) {
				return "1/(" + ProductListToStringSimplified (this.BelowProducts) + ")";
			} else if (belowIsIdentity) {
				return "(" + ProductListToStringSimplified (this.AboveProducts) + ")";
			} else {
				var strb = new System.Text.StringBuilder ();
				strb.Append ("(");
				strb.Append (ProductListToStringSimplified (this.AboveProducts));
				strb.Append (")/(");
				strb.Append (ProductListToStringSimplified (this.BelowProducts));
				strb.Append (")");
				return strb.ToString ();
			}
		}

		public override string ToString (ExpressionFormat format) {
			switch (format) {
				case ExpressionFormat.Normal: return ToStringNormal ();
				case ExpressionFormat.Simplified: return ToStringSimplified ();
			}

			throw new NotImplementedException ();
		}

		private static List<Product> Add (List<Product> a, List<Product> b) {
			var list = new List<Product> ();
			int na = a.Count;
			int nb = b.Count;
			int ia = 0;
			int ib = 0;
			while (ia < na || ib < nb) {
				var pa = ia < na ? a [ia] : null;
				var pb = ib < nb ? b [ib] : null;
				var cmp = Product.CompareVariableExponent (pa, pb);
				if (cmp == -1) {
					if (pa.Scalar != 0) {
						list.Add (pa.Copy ());
					}

					ia++;
				} else if (cmp == 1) {
					if (pb.Scalar != 0) {
						list.Add (pb.Copy ());
					}

					ib++;
				} else {
					if (pa.Scalar != 0 || pb.Scalar != 0) {
						var newp = new Product () {
							Scalar = pa.Scalar + pb.Scalar,
							Items = pa.CopyItems ()
						};
						if (newp.Scalar != 0) {
							list.Add (newp);
						}
					}

					ia++;
					ib++;
				}
			}
			
			return list;
		}

		public override Real Add (Real b) {
			var a = this;
			return new Real () {
				AboveProducts = Add (Multiply (a.AboveProducts, b.BelowProducts),
					Multiply (a.BelowProducts, b.AboveProducts)),
				BelowProducts = Multiply (a.BelowProducts, b.BelowProducts)
			};
		}

		private static List<Product> Multiply (List<Product> a, List<Product> b) {
			var list = new List<Product> ();
			int n = a.Count;
			int m = b.Count;
			for (int i = 0; i < n; i++) {
				var pa = a [i];
				for (int j = 0; j < m; j++) {
					var pb = b [j];
					var pab = pa.Multiply (pb);
					list = Add (list, new List<Product> () {pab});
				}
			}

			return list;
		}

		public override Real Multiply (Real b) {
			var a = this;
			return new Real () {
				AboveProducts = Multiply (a.AboveProducts, b.AboveProducts),
				BelowProducts = Multiply (a.BelowProducts, b.BelowProducts)
			};
		}

	}
}

