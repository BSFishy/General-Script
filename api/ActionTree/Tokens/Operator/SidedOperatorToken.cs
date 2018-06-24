using System;

namespace GeneralScript.Api.ActionTree.Tokens.Operator
{
    public abstract class SidedOperatorToken : OperatorToken
    {
        private readonly EType _leftSideType;
        private readonly EType _rightSideType;

        private IHasOutput _leftSide;
        private IHasOutput _rightSide;

        private readonly Func<IHasOutput, IHasOutput, ActionTreeToken> _delegate;

        protected SidedOperatorToken(EType output, EType leftSideType, EType rightSideType, Func<IHasOutput, IHasOutput, ActionTreeToken> dele) : base(output)
        {
            _leftSideType = leftSideType;
            _rightSideType = rightSideType;

            _delegate = dele;
        }
        
//        public override void Instantiate(params dynamic[] input)
//        {
//            ArgumentCheck(new []{typeof(IHasOutput), typeof(IHasOutput)}, input);
//
//            if (((IHasOutput) input[0]).OutputType() != _leftSideType ||
//                ((IHasOutput) input[1]).OutputType() != _rightSideType)
//            {
//                // TODO: use custom error instead of this
//                throw new ArgumentException("Expected to recieve a " + _leftSideType + " and a " + _rightSideType + ".");
//            }
//
//            _leftSide = input[0];
//            _rightSide = input[1];
//        }

        public void SetLeftSide(IHasOutput leftSide)
        {
            if(_leftSide != null)
                // ToDO: create custom error
                throw new ArgumentException("Cannot set left side multiple times");

            if(_leftSideType != leftSide.OutputType())
                // TODO: use custom error instead of this
                throw new ArgumentException("Incompatible output types");

            _leftSide = leftSide;
        }

        public void SetRightSide(IHasOutput rightSide)
        {
            if(_rightSide != null)
                // ToDO: create custom error
                throw new ArgumentException("Cannot set right side multiple times");
            
            if(_rightSideType != rightSide.OutputType())
                // TODO: use custom error instead of this
                throw new ArgumentException("Incompatible output types");

            _rightSide = rightSide;
        }

        public override ActionTreeToken Perform()
        {
            return _delegate(_leftSide, _rightSide);
        }
    }
}