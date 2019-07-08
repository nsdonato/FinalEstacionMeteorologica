import React from "react";
import Card from "react-bootstrap/Card";
import ListGroup from "react-bootstrap/ListGroup";

const WeatherStatistics = props => {
  return (
    <Card style={{ width: props.style.width }}>
        <Card.Header>Statistics</Card.Header>
        <Card.Body>
          <Card.Text>
            {props.data.isSuscribed === false
              ? "Statistics is not available"
              : props.data.information}
          </Card.Text>
          <Card.Header>Last 3 temperatures</Card.Header>
          <Card.Text>
          <ListGroup variant="flush">
            {props.data.lastData.map((item, key) => (
              <ListGroup.Item key={key}>Temperature: {item.temp}°</ListGroup.Item>
            ))}
          </ListGroup>
          </Card.Text>
        </Card.Body>
      </Card>
  );
};

export default WeatherStatistics;
