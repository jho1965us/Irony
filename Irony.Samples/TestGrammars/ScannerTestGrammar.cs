﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Irony.CompilerServices;

namespace Irony.Samples {
  public class ScannerTestGrammar : Grammar {
    public ScannerTestGrammar() {
      var distance = new NumberLiteral("distance", NumberFlags.AllowSign);
      var name = new IdentifierTerminal("name", TextUtils.DecimalDigits, TextUtils.DecimalDigits);

      var Tree = new NonTerminal("Tree");
      var SubTree = new NonTerminal("SubTree");
      var Leaf = new NonTerminal("Leaf");
      var Internal = new NonTerminal("Internal");
      var BranchList = new NonTerminal("BranchList");
      var Branch = new NonTerminal("Branch");
      var Length = new NonTerminal("Length");
      var Name = new NonTerminal("Name");

      Tree.Rule = SubTree + ";";
      SubTree.Rule = Leaf | Internal;
      Leaf.Rule = Empty | name;
      Internal.Rule = "(" + BranchList + ")" + Name;
      BranchList.Rule = Branch | Branch + "," + BranchList;
      Branch.Rule = SubTree + Length;
      Length.Rule = Empty | ":" + distance;
      Name.Rule = Empty | name;

      this.Root = Tree;       // Set grammar root
      RegisterPunctuation("(", ")");
      this.LanguageFlags |= LanguageFlags.ComputeExpectedTerms;

    }//constructor

  }//class
}