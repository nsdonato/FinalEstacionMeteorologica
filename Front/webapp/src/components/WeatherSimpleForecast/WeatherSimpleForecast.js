import React from "react";
import Card from "react-bootstrap/Card";
import CONFIG from '../../config/config';
import cloudy from '../../images/cloudy.png';
import sunny from '../../images/sunny.png';

const WeatherSimpleForecast = props => {
  return (
    <Card style={{ width: props.style.width }}>
      <Card.Header>Simple Forecast</Card.Header>
      <Card.Body>
        <Card.Text>
          {props.data.isSuscribed === false ? CONFIG.FORECAST_UNAVAILABLE : props.data.forecast}
        </Card.Text>
        <Card.Img variant="top" src={ props.data.isSunny ? sunny : cloudy }></Card.Img>
      </Card.Body>
    </Card>
  );
};

export default WeatherSimpleForecast;
