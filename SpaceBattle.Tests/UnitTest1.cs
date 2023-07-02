using spacebattle;
using System;
using TechTalk.SpecFlow;

namespace spacebattletests.StepDefinitions
{
    [Binding]
    public class StepDefinitions
    {
        Spaceship spaceship = new Spaceship();
        int[]? actual_coordinates;
        double? remainingfuel;
        int? newangle;
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

        [Given(@"космический корабль, угол наклона которого невозможно определить")]
        public void GivenImpossibleAngle()
        {

        }

        [Given(@"мгновенную угловую скорость невозможно определить")]
        public void GivenImpossibleAngleSpeed()
        {

        }

        [Given(@"невозможно изменить уголд наклона к оси OX космического корабля")]
        public void GivenImpossibleAngleCalculation()
        {
            spaceship.CannotAngleAction();
        }

        [Given(@"изменить положение в пространстве космического корабля невозможно")]
        public void GivenImpossibleAction()
        {
            spaceship.CannotAction();
        }

        [Given(@"космический корабль имеет топливо в объеме (.*) ед")]
        public void GivenFuelCount(double f)
        {
            spaceship.SetFuel(f);
        }

        [Given(@"имеет скорость расхода топлива при движении (.*) ед")]
        public void GivenFuelFlow(double f)
        {
            spaceship.SetFuelFlow(f);
        }

        [Given(@"космический корабль имеет угол наклона (.*) град к оси OX")]
        public void GivenAngle(int angle)
        {
            spaceship.SetAngle(angle);
        }

        [Given(@"имеет мгновенную угловую скорость (.*) град")]
        public void GivenAngleSpeed(int angle_sp)
        {
            spaceship.SetAngleSpeed(angle_sp);
        }

        [When(@"происходит прямолинейное равномерное движение без деформации"), Scope(Tag = "Fuel")]
        public void WhenMovingActionFuelCheckOnly()
        {
            try
            {
                remainingfuel = spaceship.FuelAfterAction();

            }
            catch (Exception ex)
            {
                exception = ex;
            }
        }

        [When(@"происходит прямолинейное равномерное движение без деформации"), Scope(Tag = "Moving")]
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

        [When(@"происходит вращение вокруг собственной оси")]
        public void WhenMovingActionAngleCheckOnle()
        {
            try
            {
                newangle = spaceship.AngleCalculation();

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
            Assert.IsType<Exception>(exception);
        }

        [Then(@"новый объем топлива космического корабля равен (.*) ед")]
        public void ThenSpaceshipHaveThisCountFuel(int fuel)
        {
            Assert.Equal(fuel, remainingfuel);
        }

        [Then(@"угол наклона космического корабля к оси OX составляет (.*) град")]
        public void ThenSpaceshipNowThisAngle(int angle)
        {
            Assert.Equal(angle, newangle);
        }
    }
}