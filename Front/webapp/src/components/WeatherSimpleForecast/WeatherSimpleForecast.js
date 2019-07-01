import React from "react";
import Card from "react-bootstrap/Card";
import Col from "react-bootstrap/Col";

const WeatherSimpleForecast = props => {
  
  return (
     
    <Col>
    <Card style={{ width: "18rem" }}>
      <Card.Img
        variant="top"
        src="http://www.placehold.it/100/100/"
      />
      <Card.Body>
        <Card.Title>Simple Forecast</Card.Title>
        <Card.Text>
          {props.data.isSuscribed === false ? "Simple Forecast is not available" : props.data.forecast}
        </Card.Text>
      </Card.Body>
    </Card>
  </Col>
  );
};

export default WeatherSimpleForecast;
