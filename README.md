# Restaurant Booking assignment

Develop a restaurant booking system where clients can reserve tables for dinner (for simpliciy consider a time slot only and no hour/day is required for booking)

Requirements:
 * A reastaurant must exposes the following:
   * Restaurant name
   * Owner name
   * Available tables
   * Available seats
 * When requesting a reservation at the restaurant a client must provide a name, a contact and number of people
 * A reservation request may end up with either:
   * A booking confirmation, in the form of a report containing the booking id and reservee name
   * A reject response in case there are not enough seats to accomodate guests
 * A restaurant always allows booking of tables, not single seats. As a consequence:
   * A table cannot be shared between different reservations (ie: client A takes table K for 1 seat and client B takes table K for 3 seats)
   * A table doesn't have to be filled
   * A client can have multiple tables booked as result of a single reservation
