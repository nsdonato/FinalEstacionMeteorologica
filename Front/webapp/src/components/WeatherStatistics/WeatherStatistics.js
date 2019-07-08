import React from "react";
import Card from "react-bootstrap/Card";
import Col from "react-bootstrap/Col";
import ListGroup from "react-bootstrap/ListGroup";
import CONFIG from '../../config/config';
import Row from "react-bootstrap/Row";

const WeatherStatistics = props => {
  return (
    <Card  style={{ width: props.style.width }}>
        <Card.Header >Statistics</Card.Header>
        <Card.Body>
          <Card.Text>
            {props.data.isSuscribed === false
              ? CONFIG.STATISTICS_UNAVAILABLE
              : props.data.information}
          </Card.Text>
          <Card.Header className="bg-dark text-white">Last {props.data.lastData.length} temperatures</Card.Header>
          <Card.Text>
          <Card.Text>
            <Row>
              <Col>
            Min Temp: {props.data.minimumTemperature} °
            </Col>
            <Col>
            Max Temp: {props.data.maximumTemperature} °
            </Col>
            </Row>
          </Card.Text>
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
