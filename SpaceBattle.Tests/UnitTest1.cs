using spacebattle;
using System;
using TechTalk.SpecFlow;

namespace spacebattletests.StepDefinitions
{
    [Binding]
    public class MovingActionStepDefinitions
    {
        Spaceship spaceship = new Spaceship();
        int[]? actual_coordinates;
        Exception exception = new Exception();

        [Given(@"космический корабль находится в точке пространства с координатами \((.*), (.*)\)")]
        public void GivenCoordinates(int p0, int p1)
        {
            spaceship.SetCoordinates(p0, p1);
        }

        [Given(@"имеет мгновенную скорость \((.*), (.*)\)")]
        public void GivenSpeedVector(int p0, int p1)
        {
            spaceship.SetSpeedVector(p0, p1);
        }

        [Given(@"космический корабль, положение в пространстве которого невозможно определить")]
        public void GivenImpossibleCoordinates()
        {

        }

        [Given(@"скорость корабля определить невозможно")]
        public void GivenImpossibleSpeedVector()
        {

        }

        [Given(@"изменить положение в пространстве космического корабля невозможно")]
        public void GivenImpossibleAction()
        {
            spaceship.CannotAction();
        }

        [When(@"происходит прямолинейное равномерное движение без деформации")]
        public void WhenMovingAction()
        {
            try
            {
                actual_coordinates = spaceship.MovingAction();
            }
            catch (Exception ex)
            {
                exception = ex;
            }
        }

        [Then(@"космический корабль перемещается в точку пространства с координатами \((.*), (.*)\)")]
        public void ThenSpaceshipMovingToCoordinates(int p0, int p1)
        {
            Assert.Equal(new int[] { p0, p1 }, actual_coordinates);
        }

        [Then(@"возникает ошибка Exception")]
        public void ThenThrowsException()
        {
            Assert.Equal("coordinates or speed vector was null", exception.Message);
        }
    }
}
