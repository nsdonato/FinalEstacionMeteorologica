import React from "react";
import Card from "react-bootstrap/Card";
import Col from "react-bootstrap/Col";

const WeatherSimpleForecast = props => {
  
  return (
    <Card style={{ width: props.style.width }}>
      <Card.Header>Simple Forecast</Card.Header>
      <Card.Body>
        <Card.Text>
          {props.data.isSuscribed === false ? "Simple Forecast is not available" : props.data.forecast}
        </Card.Text>
      </Card.Body>
    </Card>
  );
};

export default WeatherSimpleForecast;
