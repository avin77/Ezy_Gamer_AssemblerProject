using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HindiCorrector {


	public class GSUB {
		public string source;
		public string dest;
	}

	// GSUB table
	private static GSUB[] gsub = new GSUB [] {
		// ligatures
		new GSUB () { source = "\u091F\u094D\u091F", dest = "\uF5A2\uF61F" },
		new GSUB () { source = "\u0920\u094D\u0920", dest = "\uF5A3\uF625" },
		new GSUB () { source = "\u0921\u094D\u0921", dest = "\uF5A4\uF62B" },
		new GSUB () { source = "\u0922\u094D\u0922", dest = "\uF5A5\uF633" },
		new GSUB () { source = "\u0926\u094D\u0926", dest = "\uF45A" },
		//new GSUB () { source = "\u0929\u094D\u0929", dest = "\u0929\u0929" }, // not found 
		//new GSUB () { source = "\u0934\u094D\u0934", dest = "\u0934\u0934" }, // not found

		new GSUB () { source = "\u0915\u094D\u0930", dest = "\uF3D1" },
		new GSUB () { source = "\u0916\u094D\u0930", dest = "\uF364" },
		new GSUB () { source = "\u0917\u094D\u0930", dest = "\uF365" },
		new GSUB () { source = "\u0918\u094D\u0930", dest = "\uF366" },
		new GSUB () { source = "\u091A\u094D\u0930", dest = "\uF367" },
		new GSUB () { source = "\u091C\u094D\u0930", dest = "\uF368" },
		new GSUB () { source = "\u091D\u094D\u0930", dest = "\uF369" },
		new GSUB () { source = "\u091E\u094D\u0930", dest = "\uF36B" },
		new GSUB () { source = "\u091F\u094D\u0930", dest = "\u091F\uF1B0" },
		new GSUB () { source = "\u0920\u094D\u0930", dest = "\u0920\uF1B0" },
		new GSUB () { source = "\u0921\u094D\u0930", dest = "\u0921\uF1B0" },
		new GSUB () { source = "\u0922\u094D\u0930", dest = "\u0922\uF1B0" },
		new GSUB () { source = "\u0923\u094D\u0930", dest = "\uF36C" },
		new GSUB () { source = "\u0924\u094D\u0930", dest = "\uF36E" },
		new GSUB () { source = "\u0925\u094D\u0930", dest = "\uF36F" },
		new GSUB () { source = "\u0926\u094D\u0930", dest = "\uF370" },
		new GSUB () { source = "\u0927\u094D\u0930", dest = "\uF371" },
		new GSUB () { source = "\u0928\u094D\u0930", dest = "\uF373" },
		new GSUB () { source = "\u092A\u094D\u0930", dest = "\uF374" },
		new GSUB () { source = "\u092B\u094D\u0930", dest = "\uF375" },
		new GSUB () { source = "\u092C\u094D\u0930", dest = "\uF376" },
		new GSUB () { source = "\u092D\u094D\u0930", dest = "\uF377" },
		new GSUB () { source = "\u092E\u094D\u0930", dest = "\uF379" },
		new GSUB () { source = "\u092F\u094D\u0930", dest = "\uF37A" },
		new GSUB () { source = "\u0932\u094D\u0930", dest = "\uF37B" },
		new GSUB () { source = "\u0935\u094D\u0930", dest = "\uF37C" },
		new GSUB () { source = "\u0936\u094D\u0930", dest = "\uF37D" },
		new GSUB () { source = "\u0937\u094D\u0930", dest = "\uF37E" },
		new GSUB () { source = "\u0938\u094D\u0930", dest = "\uF37F" },
		new GSUB () { source = "\u0939\u094D\u0930", dest = "\uF380" },

		new GSUB () { source = "\u0930\u094D\u0915", dest = "\u0915\uF005" },
		new GSUB () { source = "\u0930\u094D\u0916", dest = "\u0916\uF306" },
		new GSUB () { source = "\u0930\u094D\u0917", dest = "\u0917\uF306" },
		new GSUB () { source = "\u0930\u094D\u0918", dest = "\u0918\uF306" },
		new GSUB () { source = "\u0930\u094D\u0919", dest = "\u0919\uF003" },
		new GSUB () { source = "\u0930\u094D\u091A", dest = "\u091A\uF306" },
		new GSUB () { source = "\u0930\u094D\u091B", dest = "\u091B\uF001" },
		new GSUB () { source = "\u0930\u094D\u091C", dest = "\u091C\uF306" },
		new GSUB () { source = "\u0930\u094D\u091D", dest = "\u091D\uF306" },
		new GSUB () { source = "\u0930\u094D\u091E", dest = "\u091E\uF306" },
		new GSUB () { source = "\u0930\u094D\u091F", dest = "\u091F\uF001" },
		new GSUB () { source = "\u0930\u094D\u0920", dest = "\u0920\uF001" },
		new GSUB () { source = "\u0930\u094D\u0921", dest = "\u0921\uF001" },
		new GSUB () { source = "\u0930\u094D\u0922", dest = "\u0922\uF001" },
		new GSUB () { source = "\u0930\u094D\u0923", dest = "\u0923\uF306" },
		new GSUB () { source = "\u0930\u094D\u0924", dest = "\u0924\uF306" },
		new GSUB () { source = "\u0930\u094D\u0925", dest = "\u0925\uF306" },
		new GSUB () { source = "\u0930\u094D\u0926", dest = "\u0926\uF000" },
		new GSUB () { source = "\u0930\u094D\u0927", dest = "\u0927\uF306" },
		new GSUB () { source = "\u0930\u094D\u0928", dest = "\u0928\uF306" },
		new GSUB () { source = "\u0930\u094D\u0929", dest = "\u0929\uF306" },
		new GSUB () { source = "\u0930\u094D\u092A", dest = "\u092A\uF306" },
		new GSUB () { source = "\u0930\u094D\u092B\u093C", dest = "\u095E\uF306" },
		new GSUB () { source = "\u0930\u094D\u092C", dest = "\u092C\uF306" },
		new GSUB () { source = "\u0930\u094D\u092D", dest = "\u092D\uF306" },
		new GSUB () { source = "\u0930\u094D\u092E", dest = "\u092E\uF306" },
		new GSUB () { source = "\u0930\u094D\u092F", dest = "\u092F\uF306" },
		new GSUB () { source = "\u0930\u094D\u0930", dest = "\u0930\uF000" },
		new GSUB () { source = "\u0930\u094D\u0931", dest = "\u0931\uF000" },
		new GSUB () { source = "\u0930\u094D\u0932", dest = "\u0932\uF002" },
		new GSUB () { source = "\u0930\u094D\u0933", dest = "\u0933\uF002" },
		new GSUB () { source = "\u0930\u094D\u0934", dest = "\u0934\uF002" },
		new GSUB () { source = "\u0930\u094D\u0935", dest = "\u0935\uF306" },
		new GSUB () { source = "\u0930\u094D\u0936", dest = "\u0936\uF306" },
		new GSUB () { source = "\u0930\u094D\u0937", dest = "\u0937\uF306" },
		new GSUB () { source = "\u0930\u094D\u0938", dest = "\u0938\uF306" },
		new GSUB () { source = "\u0930\u094D\u0939", dest = "\u0939\uF306" },

		new GSUB () { source = "\u0915\u094D\u0937", dest = "\uF337" },
		new GSUB () { source = "\u091C\u094D\u091E", dest = "\uF339" },
		new GSUB () { source = "\u0924\u094D\u0928", dest = "\uF4F5" },
		new GSUB () { source = "\u0926\u094D\u0927", dest = "\uF46A" }, // check drawing of the symbol
		new GSUB () { source = "\u0926\u094D\u092D", dest = "\uF01A" },
		new GSUB () { source = "\u0926\u094D\u092E", dest = "\uF3E3" },
		new GSUB () { source = "\u0926\u094D\u092F", dest = "\uF3E4" },
		new GSUB () { source = "\u0926\u094D\u0935", dest = "\uF493" },

		new GSUB () { source = "\u091F\u094D\u0920", dest = "\uF5A2\uF625" },
		new GSUB () { source = "\u0938\u094D\u0924", dest = "\uF35B\u0924" },

		// half letters
		new GSUB () { source = "\u0915\u094D", dest = "\uF33A" },
		new GSUB () { source = "\u0916\u094D", dest = "\uF33B" },
		new GSUB () { source = "\u0917\u094D", dest = "\uF33C" },
		new GSUB () { source = "\u0918\u094D", dest = "\uF33D" },
		new GSUB () { source = "\u091A\u094D", dest = "\uF33E" },
		new GSUB () { source = "\u091B\u094D", dest = "\uF334" },
		new GSUB () { source = "\u091C\u094D", dest = "\uF33F" },
		new GSUB () { source = "\u091D\u094D", dest = "\uF340" },
		new GSUB () { source = "\u091E\u094D", dest = "\uF343" },
		new GSUB () { source = "\u0923\u094D", dest = "\uF344" },
		new GSUB () { source = "\u0924\u094D", dest = "\uF346" },
		new GSUB () { source = "\u0925\u094D", dest = "\uF347" },
		new GSUB () { source = "\u0927\u094D", dest = "\uF348" },
		new GSUB () { source = "\u0928\u094D", dest = "\uF34A" },
		new GSUB () { source = "\u092A\u094D", dest = "\uF34B" },
		new GSUB () { source = "\u092B\u094D", dest = "\uF34C" },
		new GSUB () { source = "\u092C\u094D", dest = "\uF34D" },
		new GSUB () { source = "\u092D\u094D", dest = "\uF34E" },
		new GSUB () { source = "\u092E\u094D", dest = "\uF350" },
		new GSUB () { source = "\u092F\u094D", dest = "\uF351" },
		new GSUB () { source = "\u0931\u094D", dest = "\uF352" },
		new GSUB () { source = "\u0932\u094D", dest = "\uF353" },
		new GSUB () { source = "\u0933\u094D", dest = "\uF355" },
		new GSUB () { source = "\u0935\u094D", dest = "\uF356" },
		new GSUB () { source = "\u0936\u094D", dest = "\uF357" },
		new GSUB () { source = "\u0937\u094D", dest = "\uF35A" },
		new GSUB () { source = "\u0938\u094D", dest = "\uF35B" },
		new GSUB () { source = "\u0939\u094D", dest = "\uF35C" },

		// anusvara
		new GSUB () { source = "\u0915\u0948\u0902", dest = "\u0915\u0948\uF01B" },
		new GSUB () { source = "\u0932\u0902", dest = "\u0932\uF01B" },

		// nukta
		new GSUB () { source = "\u0922\u093C", dest = "\u095D" },

		// vowel signs u and uu
		new GSUB () { source = "\u0915\u0941", dest = "\u0915\uF018" },
		new GSUB () { source = "\u0915\u0942", dest = "\u0915\uF019" },
		new GSUB () { source = "\u0930\u0942", dest = "\uF555" },
		new GSUB () { source = "\u0939\u0941", dest = "\uF564" },
		new GSUB () { source = "\u0939\u0942", dest = "\uF565" },

		// vowel sign e
		new GSUB () { source = "\u0915\u0947", dest = "\u0915\uF00D" },
		new GSUB () { source = "\u091F\u0947", dest = "\u091F\uF008" },
		new GSUB () { source = "\u091F\uF1B0\u0947", dest = "\u091F\uF1B0\uF008" },
		new GSUB () { source = "\u0930\u0947", dest = "\u0930\uF008" },
		new GSUB () { source = "\u0932\u0947", dest = "\u0932\uF00A" },
		new GSUB () { source = "\u0933\u0947", dest = "\u0933\uF00A" },
		new GSUB () { source = "\uF375\u0947", dest = "\uF375\uF00D" },

		// vowel sign ai
		new GSUB () { source = "\u0915\u0948", dest = "\u0915\uF015" },

		// vowel sign i over symbol
		new GSUB () { source = "\uF33A\u0932\u093F", dest = "\uF31E\uF33A\u0932" },
		new GSUB () { source = "\uF35B\u091F\u093F", dest = "\uF31E\uF35B\u091F" },
		new GSUB () { source = "\uF353\u0915\u093F", dest = "\uF31E\uF353\u0915" },

		// vowel sign i
		new GSUB () { source = "\u0915\u093F", dest = "\uF311\u0915" },
		new GSUB () { source = "\u0916\u093F", dest = "\uF31E\u0916" },
		new GSUB () { source = "\u0917\u093F", dest = "\uF30C\u0917" },
		new GSUB () { source = "\u091A\u093F", dest = "\uF314\u091A" },
		new GSUB () { source = "\u091C\u093F", dest = "\uF31E\u091C" },
		new GSUB () { source = "\u091F\u093F", dest = "\uF310\u091F" },
		new GSUB () { source = "\u0920\u093F", dest = "\uF30F\u0920" },
		new GSUB () { source = "\u0921\u093F", dest = "\uF30F\u0921" },
		new GSUB () { source = "\u0924\u093F", dest = "\uF312\u0924" },
		new GSUB () { source = "\u0926\u093F", dest = "\uF30F\u0926" },
		new GSUB () { source = "\u0927\u093F", dest = "\uF312\u0927" },
		new GSUB () { source = "\u0928\u093F", dest = "\uF312\u0928" },
		new GSUB () { source = "\u092B\u093F", dest = "\uF311\u092B" },
		new GSUB () { source = "\u092C\u093F", dest = "\uF311\u092C" },
		new GSUB () { source = "\u092D\u093F", dest = "\uF314\u092D" },
		new GSUB () { source = "\u092E\u093F", dest = "\uF314\u092E" },
		new GSUB () { source = "\u0930\u093F", dest = "\uF30D\u0930" },
		new GSUB () { source = "\u0932\u093F", dest = "\uF314\u0932" },
		new GSUB () { source = "\u0935\u093F", dest = "\uF311\u0935" },
		new GSUB () { source = "\u0936\u093F", dest = "\uF317\u0936" },
		new GSUB () { source = "\u0938\u093F", dest = "\uF319\u0938" },
		new GSUB () { source = "\u0939\u093F", dest = "\uF311\u0939" },

		// vowel sign i after ligature
		new GSUB () { source = "\uF337\u093F", dest = "\uF319\uF337" },
		new GSUB () { source = "\uF376\u093F", dest = "\uF311\uF376" },

		// vowel sign ii + chandrabindu
		new GSUB () { source = "\u0940\u0901", dest = "\u0940\uF300" },

		// vowel sign ii
		new GSUB () { source = "\u0915\u0940", dest = "\u0915\uF32A" },
		new GSUB () { source = "\u091F\u0940", dest = "\u091F\uF323" },
		new GSUB () { source = "\u092B\u0940", dest = "\u092B\uF32A" },
		new GSUB () { source = "\u0930\u0940", dest = "\u0930\uF322" },
		new GSUB () { source = "\u0932\u0940", dest = "\u0932\uF325" },

		// vowel sign ii after ligature
		new GSUB () { source = "\uF363\u0940", dest = "\uF363\uF32A" }
	};


	public static string Correct (string text) {
		// GSUB replacements
		for (int i = 0; i < gsub.Length; i++) {
			text = text.Replace (gsub [i].source, gsub [i].dest);
		}

		// permutation of unaccounted vowel signs i
		string[] words = text.Split (' ');
		for (int k = 0; k < words.Length; k++) {
			char[] arr = words[k].ToCharArray ();

			for (int i = 1; i < arr.Length; i++) {
				if (arr [i] == '\u093f') {
					arr [i] = arr [i - 1];
					arr [i - 1] = '\u093f';
				}
			}

			words [k] = new string (arr);
		}
		text = string.Join (" ", words);

		return text;
	}


}
