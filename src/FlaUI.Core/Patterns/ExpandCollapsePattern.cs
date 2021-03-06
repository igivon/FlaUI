﻿using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface IExpandCollapsePattern : IPattern
    {
        IExpandCollapsePatternProperties Properties { get; }

        AutomationProperty<ExpandCollapseState> ExpandCollapseState { get; }

        void Collapse();
        void Expand();
    }

    public interface IExpandCollapsePatternProperties
    {
        PropertyId ExpandCollapseState { get; }
    }

    public abstract class ExpandCollapsePatternBase<TNativePattern> : PatternBase<TNativePattern>, IExpandCollapsePattern
    {
        private AutomationProperty<ExpandCollapseState> _expandCollapseState;

        protected ExpandCollapsePatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public IExpandCollapsePatternProperties Properties => Automation.PropertyLibrary.ExpandCollapse;

        public AutomationProperty<ExpandCollapseState> ExpandCollapseState => GetOrCreate(ref _expandCollapseState, Properties.ExpandCollapseState);

        public abstract void Collapse();
        public abstract void Expand();
    }
}
