import React from "react";
import Card from "react-bootstrap/Card";
import Col from "react-bootstrap/Col";
import Row from "react-bootstrap/Col";
// import ListGroup from "react-bootstrap/ListGroup";

const WeatherStatistics = props => {
  debugger;
  const style = {
    textAlign: "left"
  };

  return (
    <Col>
      <Card style={{ width: "18rem" }}>
        <Card.Img variant="top" src="http://www.placehold.it/100/100/" />
        <Card.Body>
          <Card.Title>Statistics</Card.Title>
          <Row>
            <Col sm={12}>
              {" "}
              <Card.Title>Last 5 temperatures</Card.Title>{" "}
            </Col>
          </Row>
          <Row>
            <Col sm={8}>
              {props.data.lastData.map((item,key) => (
                <Card.Subtitle>
                Temperature: {item.temp}°
                </Card.Subtitle>
              ))} 
            </Col>
          </Row>
          <Card.Text>
            {props.data.isSuscribed === false
              ? "Statistics is not available"
              : props.data.information}
          </Card.Text>
          {/* <ListGroup variant="flush">
            <ListGroup.Item>Cras justo odio</ListGroup.Item>
            <ListGroup.Item>Dapibus ac facilisis in</ListGroup.Item>
            <ListGroup.Item>Morbi leo risus</ListGroup.Item>
            <ListGroup.Item>Porta ac consectetur ac</ListGroup.Item>
          </ListGroup> */}
          {/* <Button variant="primary">Suscribe</Button>
           <Button variant="primary" onClick={handleUnsuscribe}> Unsuscribe </Button> */}
        </Card.Body>
      </Card>
    </Col>
  );
};

export default WeatherStatistics;
