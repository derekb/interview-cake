using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewCake
{
    public class BracketValidator
    {
        private readonly IDictionary<char, char> closerToOpener = 
            new Dictionary<char, char> {
                 {'}', '{'},
                 {']', '['},
                 {')', '('}
            };

        public bool IsValid(String input) {
            var stack = new Stack<char>();

            foreach (var c in input) {
                if (closerToOpener.Values.Contains(c)) {
                    stack.Push(c);
                } else if (closerToOpener.Keys.Contains(c)) {
                    if (!stack.Any() || closerToOpener[c] != stack.Pop()) {
                        return false;
                    }
                } else {
                    throw new Exception("Invalid input");
                }
            }
            
            return !stack.Any();
        }
    }
}
